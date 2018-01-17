using System.Collections.Generic;
using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Domain
{
    public interface IDomainEventDispatcher
    {
        Task DispatchTransactionalDomainEvents<TEvent>(IEnumerable<TEvent> domainEvent) where TEvent : class, IDomainEvent;

        Task DispatchIntegrationDomainEvents<TEvent>(IEnumerable<TEvent> domainEvent) where TEvent : class, IDomainEvent;
    }
}
