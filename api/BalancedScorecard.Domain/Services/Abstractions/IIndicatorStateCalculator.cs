using BalancedScorecard.Domain.Enums;
using BalancedScorecard.Domain.Model.Indicators;

namespace BalancedScorecard.Domain.Services.Abstractions
{
    public interface IIndicatorStateCalculator
    {
        IndicatorEnum.State Calculate(Indicator indicator);
    }
}
