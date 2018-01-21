using BalancedScorecard.Domain.Enums;
using BalancedScorecard.Domain.Model.Indicators.Values;
using BalancedScorecard.Kernel.Domain;
using System;

namespace BalancedScorecard.Domain.Events.Indicators
{
    public class BaseIndicatorMeasureEvent : IDomainEvent
    {
        public Guid IndicatorMeasureId { get; set; }

        public Guid IndicatorId { get; set; }

        public DateTime Date { get; set; }

        public IIndicatorValue RealValue { get; set; }

        public IIndicatorValue ObjectiveValue { get; set; }

        public string Notes { get; set; }

        public IndicatorEnum.Status IndicatorStatus { get; set; }
    }
}
