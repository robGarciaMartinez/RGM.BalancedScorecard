﻿namespace RGM.BalancedScorecard.Domain.CommandHandlers.Indicators
{
    using RGM.BalancedScorecard.Domain.Commands.Indicators;
    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Domain.Repositories;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public class UpdateIndicatorCommandHandler : ICommandHandler<UpdateIndicatorCommand>
    {
        private readonly IIndicatorsRepository repository;

        public UpdateIndicatorCommandHandler(IIndicatorsRepository repository)
        {
            this.repository = repository;
        }

        public CommandHandlerResponse Execute(UpdateIndicatorCommand command)
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

            return new CommandHandlerResponse();
        }
    }
}
