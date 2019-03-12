using BalancedScorecard.Kernel.Queries;
using BalancedScorecard.Query.Filter.Indicators;
using BalancedScorecard.Query.Model.Indicators;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalancedScorecard.Infrastructure.DocumentDb.Queries.Indicators
{
    public class GetIndicatorsQuery : ICollectionQuery<IndicatorViewModel, GetIndicatorsFilter>
    {
        private readonly IDocumentClient _documentDbClient;
        private readonly DocumentDbSettings _documentDbSettings;
        private const string queryText =
            "select * from Indicators where Indicators.code = '{0}' or Indicators.name = '{1}' or Indicators.description = '{2}'";

        public GetIndicatorsQuery(
            IDocumentClient documentDbClient,
            IOptions<DocumentDbSettings> documentDbOptions)
        {
            _documentDbClient = documentDbClient;
            _documentDbSettings = documentDbOptions.Value ?? throw new ArgumentNullException("Document db settings can't be null");
        }

        public async Task<List<IndicatorViewModel>> Execute(GetIndicatorsFilter filter)
        {
            var options = new FeedOptions { MaxItemCount = 50 };
            var query = _documentDbClient.CreateDocumentQuery<IndicatorViewModel>(
                UriFactory.CreateDocumentCollectionUri(_documentDbSettings.DatabaseName, Collections.Indicators),
                new SqlQuerySpec(string.Format(queryText, filter.Filter, filter.Filter, filter.Filter)),
                options)
                .AsDocumentQuery();

            return (await query.ExecuteNextAsync<IndicatorViewModel>()).ToList();
        }
    }
}
