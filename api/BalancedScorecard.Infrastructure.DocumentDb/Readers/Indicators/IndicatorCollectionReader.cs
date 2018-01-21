using BalancedScorecard.Query.Model;
using BalancedScorecard.Query.Readers.Indicators;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BalancedScorecard.Infrastructure.DocumentDb.Readers
{
    public class IndicatorCollectionReader : BaseCollectionReader, IIndicatorCollectionReader
    {
        private const string IndicatorsCollection = "Indicators";

        public IndicatorCollectionReader(IOptions<DocumentDbSettings> options): base(options)
        {
        }

        public async Task<IndicatorViewModel> GetIndicatorViewModel(Guid id)
        {
            var query = _documentClient.CreateDocumentQuery<IndicatorViewModel>(
                UriFactory.CreateDocumentCollectionUri(_dbSettings.DatabaseName, IndicatorsCollection),
                new SqlQuerySpec($"select * from Indicators where Indicators.id = '{id.ToString().ToLower()}'"),
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

        public Task CreateIndicatorViewModel(IndicatorViewModel viewModel)
        {
            return _documentClient.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(_dbSettings.DatabaseName, IndicatorsCollection),
                viewModel);
        }

        public Task ReplaceIndicatorViewModel(IndicatorViewModel viewModel)
        {
            return _documentClient.ReplaceDocumentAsync(
                UriFactory.CreateDocumentUri(_dbSettings.DatabaseName, IndicatorsCollection, viewModel.Id.ToString()),
                viewModel);
        }
    }
}
