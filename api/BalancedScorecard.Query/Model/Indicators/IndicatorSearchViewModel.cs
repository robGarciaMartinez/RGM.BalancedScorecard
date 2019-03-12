using BalancedScorecard.Kernel.Queries;
using System.Collections.Generic;

namespace BalancedScorecard.Query.Model.Indicators
{
    public class IndicatorSearchViewModel : IViewModel
    {
        public string ContinuationToken { get; set; }

        public ICollection<IndicatorViewModel> Indicators { get; set; }
    }
}
