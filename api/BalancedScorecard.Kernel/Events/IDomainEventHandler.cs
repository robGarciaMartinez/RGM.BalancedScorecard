using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Events
{
    public interface IDomainEventHandler<TEvent> where TEvent: IDomainEvent
    {
        Task Handle(TEvent domainEvent);
    }
}
