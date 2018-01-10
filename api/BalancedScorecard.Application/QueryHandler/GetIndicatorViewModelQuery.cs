using BalancedScorecard.Kernel.Queries;
using BalancedScorecard.Query.Filter;
using BalancedScorecard.Query.Model;
using System.Threading.Tasks;

namespace BalancedScorecard.Application.QueryHandler
{
    public class GetIndicatorViewModelQuery : IQuery<IndicatorViewModel, GetIndicatorViewModelFilter>
    {
        public Task<IndicatorViewModel> Execute(GetIndicatorViewModelFilter filter)
        {
            return Task.FromResult(new IndicatorViewModel() { Code = "0001", Name = "Indicator1", Description = "Test text to check what's up" });
        }
    }
}
