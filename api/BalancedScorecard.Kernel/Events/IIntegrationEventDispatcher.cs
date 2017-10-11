using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Events
{
    public interface IIntegrationEventDispatcher
    {
        Task Dispatch<TEvent>(TEvent integrationEvent) where TEvent : class, IIntegrationEvent;
    }
}
