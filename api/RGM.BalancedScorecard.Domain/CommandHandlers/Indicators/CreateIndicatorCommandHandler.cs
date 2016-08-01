namespace RGM.BalancedScorecard.Domain.CommandHandlers.Indicators
{
    using RGM.BalancedScorecard.Domain.Commands.Indicators;
    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Domain.Repositories;
    using Services.Interfaces;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public class CreateIndicatorCommandHandler : ICommandHandler<CreateIndicatorCommand>
    {
        private readonly IIndicatorsRepository repository;

        private readonly IIndicatorStateCalculator stateCalculator;

        public CreateIndicatorCommandHandler(IIndicatorsRepository repository, IIndicatorStateCalculator stateCalculator)
        {
            this.repository = repository;
            this.stateCalculator = stateCalculator;
        }

        public CommandHandlerResponse Execute(CreateIndicatorCommand command)
        {
            var indicator = new Indicator(
                command.Name,
                command.Description,
                command.StartDate,
                command.Code,
                command.Unit,
                command.Periodicity,
                command.ComparisonValue,
                command.ObjectValue,
                command.IndicatorTypeId,
                command.ResponsibleId,
                command.FulfillmentRate,
                command.Cumulative,
                command.Id);

            indicator.Create(this.stateCalculator);

            this.repository.Insert(indicator);

            return new CommandHandlerResponse();
        }
    }
}
