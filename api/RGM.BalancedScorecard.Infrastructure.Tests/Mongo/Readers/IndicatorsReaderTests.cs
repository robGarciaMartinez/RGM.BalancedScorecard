namespace RGM.BalancedScorecard.Infrastructure.Tests.Mongo.Readers
{
    using System.Linq;
    using System.Threading;

    using MongoDB.Bson.Serialization;
    using MongoDB.Driver;

    using Moq;

    using NUnit.Framework;

    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Infrastructure.Automapper;
    using RGM.BalancedScorecard.Infrastructure.Mongo.Context;
    using RGM.BalancedScorecard.Infrastructure.Mongo.Readers.Indicators;
    using RGM.BalancedScorecard.Query.Model.Indicators;

    [TestFixture]
    public class IndicatorsReaderTests
    {
        private Mock<IDbContext> context;

        private Mock<IMongoCollection<Indicator>> indicatorsCollection;

        private Mock<IAsyncCursor<Indicator>> cursor;

        private Mock<IMapper> mapper;

        private IBsonSerializerRegistry serializerRegistry;

        private IBsonSerializer<Indicator> documentSerializer;

        private IndicatorsReader reader;

        [SetUp]
        public void Setup()
        {
            this.cursor = new Mock<IAsyncCursor<Indicator>>();
            this.indicatorsCollection = new Mock<IMongoCollection<Indicator>>();
            this.indicatorsCollection.Setup(
                c =>
                c.FindSync(
                    It.IsAny<FilterDefinition<Indicator>>(),
                    It.IsAny<FindOptions<Indicator, Indicator>>(),
                    It.IsAny<CancellationToken>())).Returns(this.cursor.Object);

            this.context = new Mock<IDbContext>();
            this.context.Setup(c => c.Collection<Indicator>()).Returns(this.indicatorsCollection.Object);

            this.mapper = new Mock<IMapper>();

            this.serializerRegistry = BsonSerializer.SerializerRegistry;
            this.documentSerializer = this.serializerRegistry.GetSerializer<Indicator>();

            this.reader = new IndicatorsReader(this.context.Object, this.mapper.Object);
        }

        [Category("Infrastructure")]
        [Test]
        public void CanGetByCode()
        {
            // Arrange
            var code = "001";

            // Act
            this.reader.GetByCode(code);

            // Assert
            this.context.Verify(c => c.Collection<Indicator>(), Times.Once);
            this.indicatorsCollection.Verify(
                c =>
                c.FindSync(
                    It.Is<FilterDefinition<Indicator>>(
                        fd => fd.Render(this.documentSerializer, this.serializerRegistry)
                            .Elements.Count(e => e.Name.Equals("Code") && e.Value.AsString.Equals(code)) == 1),
                    It.IsAny<FindOptions<Indicator, Indicator>>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);
            this.mapper.Verify(m => m.Map<IndicatorViewModel>(It.IsAny<Indicator>()), Times.Once);
        }
    }
}
