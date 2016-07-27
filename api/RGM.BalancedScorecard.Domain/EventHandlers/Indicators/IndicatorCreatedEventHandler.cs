namespace RGM.BalancedScorecard.Domain.EventHandlers.Indicators
{
    using RGM.BalancedScorecard.Domain.Events.Indicators;
    using RGM.BalancedScorecard.SharedKernel.Domain.Events;

    public class IndicatorCreatedEventHandler : IDomainEventHandler<IndicatorCreatedEvent>
    {
        public void Handle(IndicatorCreatedEvent e)
        {
            // Handle event
        }
    }
}
