namespace RGM.BalancedScorecard.Infrastructure.Tests.Repositories
{
    using System;
    using System.Linq.Expressions;
    using System.Threading;

    using MongoDB.Driver;

    using Moq;

    using NUnit.Framework;

    using RGM.BalancedScorecard.Domain.Enums;
    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Infrastructure.Mongo.Context;
    using RGM.BalancedScorecard.Infrastructure.Mongo.Repositories.Indicators;
    using RGM.BalancedScorecard.Test.Helpers.Indicators;

    [TestFixture]
    public class IndicatorsRepositoryTests
    {
        private Mock<IDbContext> context;

        private Mock<IMongoCollection<Indicator>> indicatorsCollection;

        private Mock<IFindFluent<Indicator, Indicator>> findFluent;

        private IndicatorsRepository repository;

        [SetUp]
        public void Setup()
        {
            this.findFluent = new Mock<IFindFluent<Indicator, Indicator>>();
            this.indicatorsCollection = new Mock<IMongoCollection<Indicator>>();
            this.indicatorsCollection.Setup(c => c.FindSync(It.IsAny<Expression<Func<Indicator, bool>>>(), It.IsAny<FindOptions>()))
                .Returns(this.findFluent.Object);
            this.context = new Mock<IDbContext>();
            this.context.Setup(c => c.Collection<Indicator>()).Returns(this.indicatorsCollection.Object);

            this.repository = new IndicatorsRepository(this.context.Object);
        }

        [Test]
        [Category("Indicators")]
        public void CanFindByKey()
        {
            // Arrange
            var guid = Guid.NewGuid();

            // Act
            var result = this.repository.FindByKey(guid);

            // Assert
            this.context.Verify(c => c.Collection<Indicator>(), Times.Once);
            this.indicatorsCollection.Verify(c => c.Find(It.IsAny<Expression<Func<Indicator, bool>>>(), It.IsAny<FindOptions>()), Times.Once);
        }
    }
}
