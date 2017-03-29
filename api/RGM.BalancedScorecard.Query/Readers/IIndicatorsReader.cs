using RGM.BalancedScorecard.Query.Model.Indicators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.Query.Readers
{
    public interface IIndicatorsReader
    {
        Task<IndicatorViewModel> GetIndicatorByCodeAsync(string code);

        Task<List<IndicatorViewModel>> GetIndicatorListAsync(int page);
    }
}
