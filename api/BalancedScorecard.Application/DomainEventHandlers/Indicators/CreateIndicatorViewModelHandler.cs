using BalancedScorecard.Domain.Events.Indicators;
using BalancedScorecard.Infrastructure.DocumentDb;
using BalancedScorecard.Kernel.Events;
using BalancedScorecard.Query.Model;
using BalancedScorecard.Query.Model.Indicators;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace BalancedScorecard.Application.DomainEventHandlers.Indicators
{
    public class CreateIndicatorViewModelHandler : IDomainEventHandler<IndicatorCreatedEvent>
    {
        private readonly IDocumentClient _documentDbClient;
        private readonly DocumentDbSettings _documentDbSettings;

        public CreateIndicatorViewModelHandler(
            IDocumentClient documentDbClient,
            IOptions<DocumentDbSettings> documentDbOptions)
        {
            _documentDbClient = documentDbClient;

            if (documentDbOptions.Value == null) throw new ArgumentNullException("Document db settings can't be null");
            _documentDbSettings = documentDbOptions.Value;
        }

        public Task Handle(IndicatorCreatedEvent domainEvent)
        {
            return _documentDbClient.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(_documentDbSettings.DatabaseName, Collections.Indicators),
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
                    IndicatorValueTypeId = (int)domainEvent.IndicatorValueType,
                    ComparisonTypeId = (int)domainEvent.ComparisonType,
                    PeriodicityTypeId = (int)domainEvent.PeriodicityType
                });
        }
    }
}
