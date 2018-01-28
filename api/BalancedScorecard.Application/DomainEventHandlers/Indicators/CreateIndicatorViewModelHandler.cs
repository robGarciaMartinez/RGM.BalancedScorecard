using BalancedScorecard.Domain.Events.Indicators;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Query.Model;
using BalancedScorecard.Query.Readers.Indicators;
using Microsoft.Azure.ServiceBus;
using System.Text;
using System.Threading.Tasks;

namespace BalancedScorecard.Application.DomainEventHandlers.Indicators
{
    public class CreateIndicatorViewModelHandler : IIntegrationDomainEventHandler<IndicatorCreatedEvent>
    {
        private readonly IIndicatorCollectionReader _reader;

        public CreateIndicatorViewModelHandler(
            IIndicatorCollectionReader reader)
        {
            _reader = reader;
        }

        public async Task Handle(IndicatorCreatedEvent domainEvent)
        {
            var client = new QueueClient(
                new ServiceBusConnectionStringBuilder("Endpoint=sb://rhs-vm.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=KgBTWolG/AMjfA1f3Gw/8lhk7wOc4ghaIa9oYW2EYOg=")
                {
                    EntityPath = "indicators"
                });

            await client.SendAsync(new Message() { Body = Encoding.UTF8.GetBytes("lalalala") });

            await _reader.CreateIndicatorViewModel(
                new IndicatorViewModel
                {
                    Id = domainEvent.IndicatorId,
                    Code = domainEvent.Code,
                    Name = domainEvent.Name,
                    Description = domainEvent.Description,
                    Unit = domainEvent.Unit,
                    Status = domainEvent.IndicatorStatus,
                    Cumulative = domainEvent.Cumulative,
                    FulfillmentRate = domainEvent.FulfillmentRate,
                    IndicatorValueType = domainEvent.IndicatorValueType,
                    ComparisonType = domainEvent.ComparisonType,
                    PeriodicityType = domainEvent.PeriodicityType
                });
        }
    }
}
