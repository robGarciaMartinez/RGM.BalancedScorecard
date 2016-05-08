namespace RGM.BalancedScorecard.Domain.Commands.Indicators
{
    using System;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;
    using Repositories;
    using Model.Indicators;
    public class UpdateIndicatorCommandHandler : ICommandHandler<UpdateIndicatorCommand>
    {
        private readonly IIndicatorsRepository repository;

        public UpdateIndicatorCommandHandler(IIndicatorsRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(UpdateIndicatorCommand command)
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

            this.repository.Update(indicator);
        }
    }
}
