//using Microsoft.Azure.Documents;
//using Microsoft.Azure.Documents.Client;
using RGM.BalancedScorecard.Domain.Model.Indicators;
using RGM.BalancedScorecard.Query.Model.Indicators;
using RGM.BalancedScorecard.Query.Readers;
using System.Collections.Generic;
using System.Linq;
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

            return null;
        }

        public Task<List<IndicatorViewModel>> GetIndicatorListAsync(int page)
        {
            return null;
        }

        private IndicatorViewModel ProjectIndicatorToViewModel(Indicator indicator)
        {
            return new IndicatorViewModel
            {
                Id = indicator.Id,
                Code = indicator.Code,
                Name = indicator.Name,
                Description = indicator.Description,
                Unit = indicator.Unit,
                StartDate = indicator.StartDate,

            };
        }
    }
}
