namespace RGM.BalancedScorecard.Domain.Commands.Indicators
{
    using Enums;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    using System;

    public class IndicatorCommand : ICommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public string Code { get; set; }

        public string Unit { get; set; }

        public IndicatorEnum.PeriodicityType Periodicity { get; set; }

        public IndicatorEnum.ComparisonValueType ComparisonValue { get; set; }

        public IndicatorEnum.ObjectValueType ObjectValue { get; set; }

        public Guid IndicatorTypeId { get; set; }

        public Guid ResponsibleId { get; set; }

        public int? FulfillmentRate { get; set; }

        public bool Cumulative { get; set; }
    }
}
