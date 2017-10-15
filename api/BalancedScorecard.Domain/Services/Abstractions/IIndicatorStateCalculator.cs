using BalancedScorecard.Domain.Enums;
using BalancedScorecard.Domain.Model.Indicators;

namespace BalancedScorecard.Domain.Services.Abstractions
{
    public interface IIndicatorStateCalculator
    {
        IndicatorEnum.Status Calculate(Indicator indicator);
    }
}
