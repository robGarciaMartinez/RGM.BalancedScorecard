using BalancedScorecard.Kernel.Queries;
using BalancedScorecard.Query.Filter.Indicators;
using BalancedScorecard.Query.Model.Indicators;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BalancedScorecard.Infrastructure.DocumentDb.Queries.Indicators
{
    public class GetIndicatorQuery : IQuery<IndicatorViewModel, GetIndicatorFilter>
    {
        private readonly IDocumentClient _documentDbClient;
        private readonly DocumentDbSettings _documentDbSettings;

        public GetIndicatorQuery(
            IDocumentClient documentDbClient,
            IOptions<DocumentDbSettings> documentDbOptions)
        {
            _documentDbClient = documentDbClient;

            if (documentDbOptions.Value == null) throw new ArgumentNullException("Document db settings can't be null");
            _documentDbSettings = documentDbOptions.Value;
        }

        public async Task<IndicatorViewModel> Execute(GetIndicatorFilter filter)
        {
            var query = _documentDbClient.CreateDocumentQuery<IndicatorViewModel>(
                UriFactory.CreateDocumentCollectionUri(_documentDbSettings.DatabaseName, Collections.Indicators),
                new SqlQuerySpec($"select * from Indicators where Indicators.code = '{filter.Code}'"),
                new FeedOptions { MaxItemCount = 1 })
                .AsDocumentQuery();

            while (query.HasMoreResults)
            {
                var response = await query.ExecuteNextAsync<IndicatorViewModel>();
                if (response.Any())
                {
                    return response.Single();
                }
            }

            return default(IndicatorViewModel);
        }
    }
}
