namespace RGM.BalancedScorecard.Application.Tests.Controllers
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
        [SetUp]
        public void Setup()
        {
            this.commandBus = new Mock<ICommandBus>();
            this.reader = new Mock<IIndicatorsReader>();
            this.controller = new IndicatorsController(this.commandBus.Object, this.reader.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.controller.Dispose();
        }

        private Mock<ICommandBus> commandBus;

        private Mock<IIndicatorsReader> reader;

        private IndicatorsController controller;

        [Test]
        [Category("Application")]
        public void CanGetIndicators()
        {
            // Arrange
            var page = 1;

            // Act
            var actionResult = this.controller.GetIndicators(page);

            // Assert
            this.reader.Verify(c => c.GetIndicators(It.Is<int>(i => i.Equals(page))), Times.Once);
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
        }

        [Test]
        [Category("Application")]
        public void CanGetIndicator()
        {
            // Arrange
            var code = "001";

            // Act
            var actionResult = this.controller.GetIndicator(code);

            // Assert
            this.reader.Verify(c => c.GetByCode(It.Is<string>(s => s.Equals(code))), Times.Once);
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
        }

        [Test]
        [Category("Application")]
        public void CanCreateIndicator()
        {
            // Arrange
            var command = new CreateIndicatorCommand { Id = Guid.NewGuid(), Code = "Code" };
            this.commandBus.Setup(c => c.Submit(It.IsAny<CreateIndicatorCommand>()));

            // Act
            var actionResult = this.controller.CreateIndicator(command);

            // Assert
            this.commandBus.Verify(c => c.Submit(It.IsAny<CreateIndicatorCommand>()), Times.Once);
            Assert.IsInstanceOf<CreatedAtRouteResult>(actionResult);
        }

        [Test]
        [Category("Application")]
        public void CanUpdateIndicator()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var command = new UpdateIndicatorCommand { Id = guid, Code = "Code" };
            this.commandBus.Setup(c => c.Submit(It.IsAny<UpdateIndicatorCommand>()));

            // Act
            var actionResult = this.controller.UpdateIndicator(guid, command);

            // Assert
            this.commandBus.Verify(c => c.Submit(It.IsAny<UpdateIndicatorCommand>()), Times.Once);
            Assert.IsInstanceOf<OkResult>(actionResult);
        }
    }
}