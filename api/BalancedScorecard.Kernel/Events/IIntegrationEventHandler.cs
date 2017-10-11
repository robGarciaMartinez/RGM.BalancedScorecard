using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Events
{
    public interface ISyncIntegrationEventHandler<TEvent> where TEvent : IIntegrationEvent
    {
        void Handle(TEvent integrationEvent);
    }

    public interface IIntegrationEventHandler<TEvent> where TEvent: IIntegrationEvent
    {
        Task Handle(TEvent integrationEvent);
    }
}
