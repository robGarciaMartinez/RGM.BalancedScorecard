using System.Threading.Tasks;

namespace RGM.BalancedScorecard.Kernel.Domain.Events
{
    public interface IEventBus
    {
        Task SubmitAsync<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent;
    }
}
