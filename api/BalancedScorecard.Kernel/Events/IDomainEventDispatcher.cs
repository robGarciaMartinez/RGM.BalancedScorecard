using System.Collections.Generic;
using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Events
{
    public interface IDomainEventDispatcher
    {
        Task DispatchDomainEvents<TEvent>(IEnumerable<TEvent> domainEvent) where TEvent : class, IDomainEvent;
    }
}
