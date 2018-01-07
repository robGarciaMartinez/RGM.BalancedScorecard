using BalancedScorecard.Domain.Enums;
using BalancedScorecard.Kernel.Domain;
using System;

namespace BalancedScorecard.Domain.Events.Indicators
{
    public class BaseIndicatorEvent : IDomainEvent
    {
        public Guid IndicatorId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public string Unit { get; set; }

        public IndicatorEnum.PeriodicityType PeriodicityType { get; set; }

        public IndicatorEnum.ComparisonType ComparisonType { get; set; }

        public IndicatorEnum.IndicatorValueType IndicatorValueType { get; set; }

        public Guid? IndicatorTypeId { get; set; }

        public Guid? ResponsibleId { get; set; }

        public int? FulfillmentRate { get; set; }

        public bool Cumulative { get; set; }

        public IndicatorEnum.Status IndicatorStatus { get; set; }
    }
}
