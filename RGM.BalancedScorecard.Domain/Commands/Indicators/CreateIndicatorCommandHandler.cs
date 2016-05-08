namespace RGM.BalancedScorecard.Domain.Commands.Indicators
{
    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Domain.Repositories;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public class CreateIndicatorCommandHandler : ICommandHandler<CreateIndicatorCommand>
    {
        private readonly IIndicatorsRepository repository;

        public CreateIndicatorCommandHandler(IIndicatorsRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(CreateIndicatorCommand command)
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

            this.repository.Insert(indicator);
        }
    }
}
