namespace BalancedScorecard.Kernel.Events
{
    public interface IIntegrationEventDispatcherDependencyContainer
    {
        IIntegrationEventHandler<TEvent> GetIntegrationEventHandler<TEvent>() where TEvent : IIntegrationEvent;
    }
}
