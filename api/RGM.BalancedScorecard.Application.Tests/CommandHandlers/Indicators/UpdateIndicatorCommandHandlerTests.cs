namespace RGM.BalancedScorecard.Application.Tests.CommandHandlers.Indicators
{
    using System;

    using Moq;

    using NUnit.Framework;

    using RGM.BalancedScorecard.Application.CommandHandlers.Indicators;
    using RGM.BalancedScorecard.Domain.Commands.Indicators;
    using RGM.BalancedScorecard.Domain.Enums;
    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Domain.Repositories;
    using RGM.BalancedScorecard.SharedKernel.Domain.Validation;
    using RGM.BalancedScorecard.Test.Helpers.Indicators;

    [TestFixture]
    public class UpdateIndicatorCommandHandlerTests
    {
        private Mock<IValidator<UpdateIndicatorCommand>> validator;

        private Mock<IIndicatorsRepository> repository;

        private Indicator indicator;

        private UpdateIndicatorCommandHandler commandHandler;

        [SetUp]
        public void Setup()
        {
            this.validator = new Mock<IValidator<UpdateIndicatorCommand>>();
            this.indicator = MockDomainObjects.GetIndicator();
            this.repository = new Mock<IIndicatorsRepository>();
            this.repository.Setup(r => r.FindByKey(It.IsAny<Guid>())).Returns(this.indicator);

            this.commandHandler = new UpdateIndicatorCommandHandler(this.validator.Object, this.repository.Object);
        }

        [Test]
        [Category("Application")]
        public void CanRunOnSuccessValidation()
        {
            // Arrange
            var command = MockCommandObjects.GetUpdateIndicatorCommand();

            // Act
            this.commandHandler.OnSuccessValidation(command);

            // Assert
            this.repository.Verify(
                r =>
                r.Update(
                    It.Is<Indicator>(
                        i =>
                        i.Id.Equals(this.indicator.Id) && i.Code.Equals(command.Code)
                        && i.Description.Equals(command.Description) && i.Name.Equals(command.Name)
                        && i.ComparisonValue.Equals(command.ComparisonValue) && i.Cumulative.Equals(command.Cumulative)
                        && i.FulfillmentRate.Equals(command.FulfillmentRate)
                        && i.IndicatorTypeId.Equals(command.IndicatorTypeId)
                        && i.ObjectValue.Equals(command.ObjectValue) && i.Periodicity.Equals(command.Periodicity)
                        && i.StartDate.Equals(command.StartDate) && i.Unit.Equals(command.Unit)
                        && i.ResponsibleId.Equals(command.ResponsibleId) && i.State.Equals(this.indicator.State))),
                Times.Once);

        }
    }
}
