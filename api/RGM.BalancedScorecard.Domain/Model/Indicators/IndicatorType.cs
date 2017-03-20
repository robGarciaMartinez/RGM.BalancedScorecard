using RGM.BalancedScorecard.Kernel.Domain.Model;

namespace RGM.BalancedScorecard.Domain.Model.Indicators
{
    public class IndicatorType : DomainEntity
    {
        public IndicatorType(string name, string code)
        {
        }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}