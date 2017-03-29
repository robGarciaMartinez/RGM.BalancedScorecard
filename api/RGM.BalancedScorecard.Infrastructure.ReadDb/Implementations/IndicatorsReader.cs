using RGM.BalancedScorecard.Query.Model.Indicators;
using RGM.BalancedScorecard.Query.Readers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.Infrastructure.MongoDb.Readers.Indicators
{
    public class IndicatorsReader : IIndicatorsReader
    {
        public IndicatorsReader()
        {
        }

        public Task<IndicatorViewModel> GetIndicatorByCodeAsync(string code)
        {
            return null;
        }

        public Task<List<IndicatorViewModel>> GetIndicatorListAsync(int page)
        {
            return null;
        }
    }
}
