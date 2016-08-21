namespace RGM.BalancedScorecard.Infrastructure.Tests.Mongo.Readers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Microsoft.Extensions.Configuration;

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

        private Mock<IFindFluent<Indicator, Indicator>> findFluent;

        private Mock<IConfiguration> configuration;

        private IndicatorsReader reader;

        [SetUp]
        public void Setup()
        {
            this.cursor = new Mock<IAsyncCursor<Indicator>>();
            this.findFluent = new Mock<IFindFluent<Indicator, Indicator>>();
            this.indicatorsCollection = new Mock<IMongoCollection<Indicator>>();
            this.indicatorsCollection.Setup(
                c =>
                c.FindSync(
                    It.IsAny<FilterDefinition<Indicator>>(),
                    It.IsAny<FindOptions<Indicator, Indicator>>(),
                    It.IsAny<CancellationToken>())).Returns(this.cursor.Object);

            this.indicatorsCollection.Setup(
                c => c.Find(It.IsAny<FilterDefinition<Indicator>>(), It.IsAny<FindOptions>()))
                .Returns(this.findFluent.Object);

            this.context = new Mock<IDbContext>();
            this.context.Setup(c => c.Collection<Indicator>()).Returns(this.indicatorsCollection.Object);

            this.mapper = new Mock<IMapper>();

            this.configuration = new Mock<IConfiguration>();

            this.serializerRegistry = BsonSerializer.SerializerRegistry;
            this.documentSerializer = this.serializerRegistry.GetSerializer<Indicator>();

            this.reader = new IndicatorsReader(this.context.Object, this.mapper.Object, this.configuration.Object);
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

    //    [Category("Infrastructure")]
    //    [Test]
    //    public void CanGetIndicators()
    //    {
    //        // Arrange
    //        var page = 1;

    //        // Act
    //        this.reader.GetIndicators(page);

    //        // Assert
    //        this.context.Verify(c => c.Collection<Indicator>(), Times.Once);
    //        this.mapper.Verify(m => m.Map<List<IndicatorViewModel>>(It.IsAny<List<Indicator>>()), Times.Once);
    //    }
    //}
}
