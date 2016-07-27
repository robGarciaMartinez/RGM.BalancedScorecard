namespace RGM.BalancedScorecard.Domain.Factories.Indicators
{
    using System;

    using RGM.BalancedScorecard.Domain.Commands.Indicators;
    using RGM.BalancedScorecard.Domain.Model.Indicators;

    public class IndicatorsFactory : IDomainEntityFactory<IIndicator, CreateIndicatorCommand>
    {
        public IIndicator Create(CreateIndicatorCommand command)
        {
            var id = Guid.NewGuid();
            return new Indicator(
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
                id);
        }
    }
}
