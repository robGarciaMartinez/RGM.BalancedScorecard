using BalancedScorecard.Kernel.Queries;

namespace BalancedScorecard.Query.Filter.Indicators
{
    public class GetIndicatorViewModelFilter : IFilter
    {
        public GetIndicatorViewModelFilter(string code)
        {
            Code = code;
        }

        public string Code { get; set; }
    }
}
