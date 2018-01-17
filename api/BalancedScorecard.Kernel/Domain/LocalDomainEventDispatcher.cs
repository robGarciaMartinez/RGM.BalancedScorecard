using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Domain
{
    public class LocalDomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IDomainEventDispatcherDependencyContainer _dependencyContainer;

        public LocalDomainEventDispatcher(IDomainEventDispatcherDependencyContainer dependencyContainer)
        {
            _dependencyContainer = dependencyContainer;
        }

        public Task DispatchTransactionalDomainEvents<TEvent>(IEnumerable<TEvent> domainEvents) where TEvent : class, IDomainEvent
        {
            var tasks = new List<Task>();
            foreach (var domainEvent in domainEvents)
            {
                foreach (var handler in _dependencyContainer.GetTransactionalDomainEventHandlers(domainEvent.GetType()))
                {
                    var handleMethod = handler.GetType().GetMethod("Handle", new Type[] { domainEvent.GetType() });
                    tasks.Add((Task)handleMethod.Invoke(handler, new[] { domainEvent }));
                }
            }

            return Task.WhenAll(tasks);
        }

        public Task DispatchIntegrationDomainEvents<TEvent>(IEnumerable<TEvent> domainEvents) where TEvent : class, IDomainEvent
        {
            var tasks = new List<Task>();
            foreach (var domainEvent in domainEvents)
            {
                foreach (var handler in _dependencyContainer.GetIntegrationDomainEventHandlers(domainEvent.GetType()))
                {
                    var handleMethod = handler.GetType().GetMethod("Handle", new Type[] { domainEvent.GetType() });
                    tasks.Add((Task)handleMethod.Invoke(handler, new[] { domainEvent }));
                }
            }

            return Task.WhenAll(tasks);
        }
    }
}
