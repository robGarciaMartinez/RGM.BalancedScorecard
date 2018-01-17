using BalancedScorecard.Domain.Events.Indicators;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Query.Model;
using BalancedScorecard.Query.Readers.Indicators;
using System.Threading.Tasks;

namespace BalancedScorecard.Application.DomainEventHandlers.Indicators
{
    public class CreateIndicatorViewModel : IIntegrationDomainEventHandler<IndicatorCreatedEvent>
    {
        private readonly IIndicatorCollectionReader _reader;

        public CreateIndicatorViewModel(IIndicatorCollectionReader reader)
        {
            _reader = reader;
        }

        public Task Handle(IndicatorCreatedEvent domainEvent)
        {
            return _reader.CreateIndicatorViewModel(
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
