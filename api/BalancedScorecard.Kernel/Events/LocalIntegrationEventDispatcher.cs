using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Events
{
    public class LocalIntegrationEventDispatcher : IIntegrationEventDispatcher
    {
        private readonly IIntegrationEventDispatcherDependencyContainer _dependencyContainer;

        public LocalIntegrationEventDispatcher(IIntegrationEventDispatcherDependencyContainer dependencyContainer)
        {
            _dependencyContainer = dependencyContainer;
        }

        public Task Dispatch<TEvent>(TEvent integrationEvent) where TEvent : class, IIntegrationEvent
        {
            var integrationEventHandler = _dependencyContainer.GetIntegrationEventHandler<TEvent>();
            return integrationEventHandler.Handle(integrationEvent);
        }
    }
}
