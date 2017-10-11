using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Domain
{
    public interface IDomainEventDispatcher
    {
        Task DispatchTransactionalDomainEvents<TEvent>(TEvent domainEvent) where TEvent : class, IDomainEvent;

        Task DispatchIntegrationDomainEvents<TEvent>(TEvent domainEvent) where TEvent : class, IDomainEvent;
    }
}
