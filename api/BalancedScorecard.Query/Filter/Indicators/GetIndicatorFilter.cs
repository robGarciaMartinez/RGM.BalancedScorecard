using BalancedScorecard.Kernel.Queries;

namespace BalancedScorecard.Query.Filter.Indicators
{
    public class GetIndicatorFilter : IFilter
    {
        public GetIndicatorFilter(string code)
        {
            Code = code;
        }

        public string Code { get; set; }
    }
}
