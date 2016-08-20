namespace RGM.BalancedScorecard.Infrastructure.Tests.Mongo.Repositories
{
    using System;
    using System.Linq;
    using System.Threading;

    using MongoDB.Bson.Serialization;
    using MongoDB.Driver;

    using Moq;

    using NUnit.Framework;

    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Infrastructure.Mongo.Context;
    using RGM.BalancedScorecard.Infrastructure.Mongo.Repositories.Indicators;
    using RGM.BalancedScorecard.Test.Helpers.Indicators;

    [TestFixture]
    public class IndicatorsRepositoryTests
    {
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

            this.repository = new IndicatorsRepository(this.context.Object);
        }

        private Mock<IDbContext> context;

        private Mock<IMongoCollection<Indicator>> indicatorsCollection;

        private Mock<IAsyncCursor<Indicator>> cursor;

        private IndicatorsRepository repository;

        [Test]
        [Category("Infrastructure")]
        public void CanFindByKey()
        {
            // Arrange
            var guid = Guid.NewGuid();

            // Act
            this.repository.FindByKey(guid);

            // Assert
            var serializerRegistry = BsonSerializer.SerializerRegistry;
            var documentSerializer = serializerRegistry.GetSerializer<Indicator>();

            this.context.Verify(c => c.Collection<Indicator>(), Times.Once);
            this.indicatorsCollection.Verify(
                c =>
                c.FindSync(
                    It.Is<FilterDefinition<Indicator>>(
                        fd => fd.Render(documentSerializer, serializerRegistry)
                            .Elements.Count(e => e.Name.Equals("_id") && e.Value.AsGuid.Equals(guid)) == 1),
                    It.IsAny<FindOptions<Indicator, Indicator>>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Test]
        [Category("Infrastructure")]
        public void CanFindByCode()
        {
            // Arrange
            var code = "001";

            // Act
            this.repository.FindByCode(code);

            // Assert
            var serializerRegistry = BsonSerializer.SerializerRegistry;
            var documentSerializer = serializerRegistry.GetSerializer<Indicator>();

            this.context.Verify(c => c.Collection<Indicator>(), Times.Once);
            this.indicatorsCollection.Verify(
                c =>
                c.FindSync(
                    It.Is<FilterDefinition<Indicator>>(
                        fd => fd.Render(documentSerializer, serializerRegistry)
                            .Elements.Count(e => e.Name.Equals("Code") && e.Value.AsString.Equals(code)) == 1),
                    It.IsAny<FindOptions<Indicator, Indicator>>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Test]
        [Category("Infrastructure")]
        public void CanInsertIndicator()
        {
            // Arrange
            var indicator = MockDomainObjects.GetIndicator();

            // Act
            this.repository.Insert(indicator);

            // Verify
            this.context.Verify(c => c.Collection<Indicator>(), Times.Once);
            this.indicatorsCollection.Verify(c => c.InsertOne(It.IsAny<Indicator>(),It.IsAny<InsertOneOptions>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        [Category("Infrastructure")]
        public void CanUpdateIndicator()
        {
            // Arrange
            var indicator = MockDomainObjects.GetIndicator();

            // Act
            this.repository.Update(indicator);

            // Verify
            this.context.Verify(c => c.Collection<Indicator>(), Times.Once);
            this.indicatorsCollection.Verify(
                c =>
                c.FindOneAndReplace(
                    It.IsAny<FilterDefinition<Indicator>>(),
                    It.IsAny<Indicator>(),
                    It.IsAny<FindOneAndReplaceOptions<Indicator>>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Test]
        [Category("Infrastructure")]
        public void CanDeleteIndicator()
        {
            // Arrange
            var guid = Guid.NewGuid();

            // Act
            this.repository.Delete(guid);

            // Verify
            this.context.Verify(c => c.Collection<Indicator>(), Times.Once);
            this.indicatorsCollection.Verify(
                c =>
                c.DeleteOne(
                    It.IsAny<FilterDefinition<Indicator>>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}