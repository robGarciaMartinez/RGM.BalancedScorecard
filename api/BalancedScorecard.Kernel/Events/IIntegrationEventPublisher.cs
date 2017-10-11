using System.Collections.Generic;
using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Events
{
    public interface IIntegrationEventPublisher
    {
        Task Publish<TEvent>(TEvent integrationEvent) where TEvent : IIntegrationEvent;

        Task PublishBatch<TEvent>(ICollection<TEvent> integrationEventCollection) where TEvent : IIntegrationEvent;
    }
}
