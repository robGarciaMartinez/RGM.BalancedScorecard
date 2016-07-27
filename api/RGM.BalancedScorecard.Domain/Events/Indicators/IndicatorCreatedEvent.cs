namespace RGM.BalancedScorecard.Domain.Events.Indicators
{
    using System;

    using RGM.BalancedScorecard.SharedKernel.Domain.Events;

    public class IndicatorCreatedEvent : IDomainEvent
    {
        public Guid IndicatorId { get; set; }
    }
}
