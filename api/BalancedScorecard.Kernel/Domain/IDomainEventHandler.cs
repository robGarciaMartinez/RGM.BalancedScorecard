using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Domain
{
    public interface ISyncDomainEventHandler<TEvent> where TEvent : IDomainEvent
    {
        void Handle(TEvent domainEvent);
    }

    public interface ITransactionalDomainEventHandler<TEvent> where TEvent: IDomainEvent
    {
        Task Handle(TEvent domainEvent);
    }

    public interface IIntegrationDomainEventHandler<TEvent> where TEvent : IDomainEvent
    {
        Task Handle(TEvent domainEvent);
    }
}
