using RGM.BalancedScorecard.Domain.Enums;
using RGM.BalancedScorecard.Domain.Model.Indicators;

namespace RGM.BalancedScorecard.Domain.Services.Abstractions
{
    public interface IIndicatorStateCalculator
    {
        IndicatorEnum.State Calculate(Indicator indicator);
    }
}
