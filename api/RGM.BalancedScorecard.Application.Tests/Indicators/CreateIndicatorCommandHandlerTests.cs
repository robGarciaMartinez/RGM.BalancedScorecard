namespace RGM.BalancedScorecard.Application.Tests.Indicators
{
    using System;

    using Moq;

    using NUnit.Framework;

    using RGM.BalancedScorecard.Application.CommandHandlers.Indicators;
    using RGM.BalancedScorecard.Domain.Commands.Indicators;
    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Domain.Repositories;
    using RGM.BalancedScorecard.Domain.Services.Interfaces;
    using RGM.BalancedScorecard.SharedKernel.Domain.Validation;

    [TestFixture]
    public class CreateIndicatorCommandHandlerTests
    {
        private Mock<IValidator<CreateIndicatorCommand>> validator;

        private Mock<IIndicatorsRepository> repository;

        private Mock<IIndicatorStateCalculator> stateCalculator;

        private CreateIndicatorCommandHandler commandHandler;

        [SetUp]
        public void Setup()
        {
            this.validator = new Mock<IValidator<CreateIndicatorCommand>>();
            this.repository = new Mock<IIndicatorsRepository>();
            this.stateCalculator = new Mock<IIndicatorStateCalculator>();
            this.commandHandler = new CreateIndicatorCommandHandler(
                this.validator.Object,
                this.repository.Object,
                this.stateCalculator.Object);
        }

        [Test]
        [Category("Indicators")]
        public void CanRunOnSuccessValidation()
        {
            // Arrange
            var command = new CreateIndicatorCommand() { Id = Guid.NewGuid(), Code = "Code" };

            // Act
            this.commandHandler.OnSuccessValidation(command);

            // Assert
            this.repository.Verify(r => r.Insert(It.IsAny<Indicator>()), Times.Once);
        }
    }
}
