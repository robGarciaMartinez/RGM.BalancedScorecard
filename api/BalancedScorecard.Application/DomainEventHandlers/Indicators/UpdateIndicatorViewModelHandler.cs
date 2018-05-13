using BalancedScorecard.Domain.Events.Indicators;
using BalancedScorecard.Infrastructure.DocumentDb;
using BalancedScorecard.Kernel.Events;
using BalancedScorecard.Kernel.Exceptions;
using BalancedScorecard.Query.Model.Indicators;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalancedScorecard.Application.DomainEventHandlers.Indicators
{
    public class UpdateIndicatorViewModelHandler : IDomainEventHandler<IndicatorMeasureCreatedEvent>
    {
        private readonly IDocumentClient _documentDbClient;
        private readonly DocumentDbSettings _documentDbSettings;

        public UpdateIndicatorViewModelHandler(
            IDocumentClient documentDbClient,
            IOptions<DocumentDbSettings> documentDbOptions)
        {
            _documentDbClient = documentDbClient;

            if (documentDbOptions.Value == null) throw new ArgumentNullException("Document db settings can't be null");
            _documentDbSettings = documentDbOptions.Value;
        }

        public async Task Handle(IndicatorMeasureCreatedEvent domainEvent)
        {
            IndicatorViewModel viewModel = null;
            var query = _documentDbClient.CreateDocumentQuery<IndicatorViewModel>(
                UriFactory.CreateDocumentCollectionUri(_documentDbSettings.DatabaseName, Collections.Indicators),
                new SqlQuerySpec($"select * from Indicators where Indicators.id = '{domainEvent.IndicatorId.ToString().ToLower()}'"),
                new FeedOptions { MaxItemCount = 1 })
                .AsDocumentQuery();

            while (query.HasMoreResults)
            {
                var response = await query.ExecuteNextAsync<IndicatorViewModel>();
                if (response.Any())
                {
                    viewModel = response.Single();
                }
            }

            if (viewModel == null) throw new ItemNotFoundException("Viewmodel not found");

            viewModel.Status = domainEvent.IndicatorStatus;
            if (viewModel.Measures == null)
            {
                viewModel.Measures = new List<IndicatorMeasureViewModel>();
            }

            viewModel.Measures.Add(new IndicatorMeasureViewModel
            {
                Date = domainEvent.Date,
                Id = domainEvent.IndicatorMeasureId,
                Notes = domainEvent.Notes,
                ObjectiveValue = domainEvent.ObjectiveValue,
                RealValue = domainEvent.RealValue
            });

            await _documentDbClient.ReplaceDocumentAsync(
                UriFactory.CreateDocumentUri(_documentDbSettings.DatabaseName, Collections.Indicators, viewModel.Id.ToString()),
                viewModel);
        }
    }
}
