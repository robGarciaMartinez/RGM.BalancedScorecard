using BalancedScorecard.Kernel.Domain;
using System;

namespace BalancedScorecard.Domain.Events.Indicators
{
    public class IndicatorCreatedEvent : IDomainEvent
    {
        public Guid IndicatorId { get; set; }
    }
}
