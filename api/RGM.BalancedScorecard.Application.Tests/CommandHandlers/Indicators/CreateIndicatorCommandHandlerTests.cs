namespace RGM.BalancedScorecard.Application.Tests.CommandHandlers.Indicators
{
    using Moq;

    using NUnit.Framework;

    using RGM.BalancedScorecard.Application.CommandHandlers.Indicators;
    using RGM.BalancedScorecard.Domain.Commands.Indicators;
    using RGM.BalancedScorecard.Domain.Enums;
    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Domain.Repositories;
    using RGM.BalancedScorecard.Domain.Services.Interfaces;
    using RGM.BalancedScorecard.SharedKernel.Domain.Validation;
    using RGM.BalancedScorecard.Test.Helpers.Indicators;

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
            this.stateCalculator.Setup(sc => sc.Calculate(It.IsAny<Indicator>())).Returns(IndicatorEnum.State.Grey);

            this.commandHandler = new CreateIndicatorCommandHandler(
                this.validator.Object,
                this.repository.Object,
                this.stateCalculator.Object);
        }

        [Test]
        [Category("Application")]
        public void CanRunOnSuccessValidation()
        {
            // Arrange
            var command = MockCommandObjects.GetCreateIndicatorCommand();

            // Act
            this.commandHandler.OnSuccessValidation(command);

            // Assert
            this.stateCalculator.Verify(sc => sc.Calculate(It.Is<Indicator>(i => !i.HasAnyMeasures())), Times.Once);
            this.repository.Verify(
                r => r.Insert(
                    It.Is<Indicator>(
                        i => 
                            i.Id.Equals(command.Id)
                            && i.Code.Equals(command.Code)
                            && i.Description.Equals(command.Description)
                            && i.Name.Equals(command.Name)
                            && i.ComparisonValue.Equals(command.ComparisonValue)
                            && i.Cumulative.Equals(command.Cumulative)
                            && i.FulfillmentRate.Equals(command.FulfillmentRate)
                            && i.IndicatorTypeId.Equals(command.IndicatorTypeId)
                            && i.ObjectValue.Equals(command.ObjectValue)
                            && i.Periodicity.Equals(command.Periodicity)
                            && i.StartDate.Equals(command.StartDate)
                            && i.Unit.Equals(command.Unit)
                            && i.ResponsibleId.Equals(command.ResponsibleId)
                            && i.State.Equals(IndicatorEnum.State.Grey)
                        )), Times.Once);
        }
    }
}
