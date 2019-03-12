using BalancedScorecard.Kernel.Queries;

namespace BalancedScorecard.Query.Filter.Indicators
{
    public class GetIndicatorsFilter : IFilter
    {
        public GetIndicatorsFilter(string filter)
        {
            Filter = filter;
        }

        public string Filter { get; set; }
    }
}
