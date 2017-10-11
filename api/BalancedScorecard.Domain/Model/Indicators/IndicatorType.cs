using BalancedScorecard.Kernel.Domain;

namespace BalancedScorecard.Domain.Model.Indicators
{
    public class IndicatorType : BaseEntity
    {
        public IndicatorType(string name, string code)
        {
        }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}