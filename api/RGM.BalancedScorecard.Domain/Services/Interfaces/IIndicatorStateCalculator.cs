namespace RGM.BalancedScorecard.Domain.Services.Interfaces
{
    using RGM.BalancedScorecard.Domain.Enums;
    using RGM.BalancedScorecard.Domain.Model.Indicators;

    public interface IIndicatorStateCalculator
    {
        IndicatorEnum.State Calculate(Indicator indicator);
    }
}
