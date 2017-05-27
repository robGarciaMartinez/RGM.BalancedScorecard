using RGM.BalancedScorecard.Kernel.Domain.Events;
using System;

namespace RGM.BalancedScorecard.Domain.Events.Indicators
{
    public class IndicatorCreatedEvent : IDomainEvent
    {
        public Guid IndicatorId { get; set; }
    }
}
