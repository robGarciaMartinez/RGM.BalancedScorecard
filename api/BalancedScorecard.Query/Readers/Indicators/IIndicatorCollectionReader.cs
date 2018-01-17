using BalancedScorecard.Query.Model;
using System;
using System.Threading.Tasks;

namespace BalancedScorecard.Query.Readers.Indicators
{
    public interface IIndicatorCollectionReader
    {
        Task<IndicatorViewModel> GetIndicatorViewModel(Guid id);

        Task CreateIndicatorViewModel(IndicatorViewModel viewModel);

        Task ReplaceIndicatorViewModel(IndicatorViewModel viewModel);
    }
}
