namespace RGM.BalancedScorecard.API.Tests
{
    using System;

    using Microsoft.AspNetCore.Mvc;

    using Moq;

    using NUnit.Framework;

    using RGM.BalancedScorecard.API.Controllers;
    using RGM.BalancedScorecard.Domain.Commands.Indicators;
    using RGM.BalancedScorecard.Query.Readers;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    [TestFixture]
    public class IndicatorsControllerTests
    {
        private Mock<ICommandBus> commandBus;

        private Mock<IIndicatorsReader> reader;

        private IndicatorsController controller;

        [SetUp]
        public void Setup()
        {
            this.commandBus = new Mock<ICommandBus>();
            this.reader = new Mock<IIndicatorsReader>();
            this.controller = new IndicatorsController(this.commandBus.Object, this.reader.Object);
        }

        [Test]
        [Category("Application")]
        public void CanCreateIndicator()
        {
            // Arrange
            var command = new CreateIndicatorCommand() { Id = Guid.NewGuid(), Code = "Code" };
            this.commandBus.Setup(c => c.Submit(It.IsAny<CreateIndicatorCommand>()));

            // Act
            var actionResult = this.controller.CreateIndicator(command);

            // Assert
            this.commandBus.Verify(c => c.Submit(It.IsAny<CreateIndicatorCommand>()), Times.Once);
            Assert.IsInstanceOf<CreatedAtRouteResult>(actionResult);
        }

        [TearDown]
        public void TearDown()
        {
            this.controller.Dispose();
        }
    }
}
