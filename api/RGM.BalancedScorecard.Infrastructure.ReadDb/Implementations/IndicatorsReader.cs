//using Microsoft.Azure.Documents;
//using Microsoft.Azure.Documents.Client;
using RGM.BalancedScorecard.Query.Model.Indicators;
using RGM.BalancedScorecard.Query.Readers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.Infrastructure.MongoDb.Readers.Indicators
{
    public class IndicatorsReader : IIndicatorsReader
    {
        //private readonly IDocumentClient _client;

        public IndicatorsReader(/*IDocumentClient client*/)
        {
            //_client = client;
        }

        public Task<IndicatorViewModel> GetIndicatorByCodeAsync(string code)
        {
            //var indicator = _client.CreateDocumentQuery<IndicatorViewModel>(UriFactory.CreateDocumentCollectionUri("BalancedScorecard","Indicators"))
                //.FirstOrDefault(i => i.Code.Equals(code));

            return Task.FromResult(new IndicatorViewModel());
        }

        public Task<List<IndicatorViewModel>> GetIndicatorListAsync(int page)
        {
            return null;
        }
    }
}
