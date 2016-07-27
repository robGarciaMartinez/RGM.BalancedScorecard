namespace RGM.BalancedScorecard.Domain.Services.Implementation
{
    using System;

    using RGM.BalancedScorecard.Domain.Enums;
    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Domain.Services.Interfaces;

    public class IndicatorStateCalculator : IIndicatorStateCalculator
    {
        public IndicatorEnum.State Calculate(Indicator indicator)
        {
            if (indicator.Measures.Count == 0)
            {
                return IndicatorEnum.State.Grey;
            }

            return IndicatorEnum.State.Grey;
            //var lastMeasure = indicator.LastMeasure;

            //if (lastMeasure?.RealValue == null)
            //{
            //    return IndicatorEnum.State.Grey;
            //}

            //if (lastMeasure.Date.AddMonths((int)indicator.Periodicity) < DateTime.Today)
            //{
            //    return IndicatorEnum.State.Grey;
            //}

            //var targetValueRate =
            //    (double)(indicator.FulfillmentRate.HasValue ? decimal.Divide(indicator.FulfillmentRate.Value, 100) : 1);

            //switch (indicator.ComparisonValue)
            //{
            //    case IndicatorEnum.ComparisonValueType.Equal:
            //        return lastMeasure.RealValue.Value.Equals(lastMeasure.TargetValue)
            //                   ? IndicatorEnum.State.Green
            //                   : IndicatorEnum.State.Red;
            //    case IndicatorEnum.ComparisonValueType.Greater:
            //        return lastMeasure.RealValue.Value > lastMeasure.TargetValue
            //                   ? IndicatorEnum.State.Green
            //                   : (lastMeasure.RealValue.Value
            //                      > lastMeasure.TargetValue - lastMeasure.TargetValue * targetValueRate
            //                          ? IndicatorEnum.State.Yellow
            //                          : IndicatorEnum.State.Red);
            //    case IndicatorEnum.ComparisonValueType.Smaller:
            //        return lastMeasure.RealValue.Value < lastMeasure.TargetValue
            //                   ? IndicatorEnum.State.Green
            //                   : (lastMeasure.RealValue.Value
            //                      < lastMeasure.TargetValue + lastMeasure.TargetValue * targetValueRate
            //                          ? IndicatorEnum.State.Yellow
            //                          : IndicatorEnum.State.Red);
            //    default:
            //        return IndicatorEnum.State.Grey;
            //}
        }
    }
}
