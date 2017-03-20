using RGM.BalancedScorecard.Domain.Enums;
using RGM.BalancedScorecard.Domain.Model.Indicators;
using RGM.BalancedScorecard.Domain.Model.Indicators.Values;
using RGM.BalancedScorecard.Domain.Services.Interfaces;
using System;

namespace RGM.BalancedScorecard.Domain.Services.Implementation
{
    public class IndicatorStateCalculator : IIndicatorStateCalculator
    {
        public IndicatorEnum.State Calculate(Indicator indicator)
        {
            if (!indicator.HasMeasures)
            {
                return IndicatorEnum.State.Grey;
            }

            var lastMeasure = indicator.LastMeasure;
            if (lastMeasure.Date.AddMonths((int)indicator.Periodicity) < DateTime.Today)
            {
                return IndicatorEnum.State.Grey;
            }

            switch (indicator.ObjectValue)
            {
                case IndicatorEnum.ObjectValueType.Integer:
                    return CalculateState<int>(indicator, lastMeasure);
                case IndicatorEnum.ObjectValueType.Decimal:
                    return CalculateState<decimal>(indicator, lastMeasure);
                case IndicatorEnum.ObjectValueType.Boolean:
                    return CalculateState<bool>(indicator, lastMeasure);
                default:
                    throw new InvalidOperationException("Indicator measure type is not correct");
            }
        }

        private IndicatorEnum.State CalculateState<T>(Indicator indicator, IndicatorMeasure lastMeasure) where T : IComparable
        {
            switch (indicator.ComparisonValue)
            {
                case IndicatorEnum.ComparisonValueType.Equal:
                case IndicatorEnum.ComparisonValueType.NotEqual:
                case IndicatorEnum.ComparisonValueType.GreaterThan:
                case IndicatorEnum.ComparisonValueType.SmallerThan:
                case IndicatorEnum.ComparisonValueType.GreaterOrEqualThan:
                case IndicatorEnum.ComparisonValueType.SmallerOrEqualThan:
                    return CalculateSingleValueBasedState<T>(indicator, lastMeasure);
                case IndicatorEnum.ComparisonValueType.BetweenLimits:
                case IndicatorEnum.ComparisonValueType.OffLimits:
                    return CalculateDoubleValueBasedState<T>(indicator, lastMeasure);
                default:
                    throw new InvalidOperationException("Indicator measure comparison value is not correct");
            }
        }

        private IndicatorEnum.State CalculateDoubleValueBasedState<T>(Indicator indicator, IndicatorMeasure lastMeasure) where T : IComparable
        {
            var recordValue = lastMeasure.Record as SingleValue<T>;
            var objectiveValue = lastMeasure.Objective as DoubleValue<T>;
            var lowerValueComparison = recordValue.Value.CompareTo(objectiveValue.LowerValue);
            var higherValueComparison = recordValue.Value.CompareTo(objectiveValue.HigherValue);
            if (recordValue == null || objectiveValue == null)
            {
                throw new InvalidOperationException("Indicator measure values are not correct");
            }

            switch (indicator.ComparisonValue)
            {
                case IndicatorEnum.ComparisonValueType.BetweenLimits:
                    return lowerValueComparison >= 0 && higherValueComparison <= 0 ? IndicatorEnum.State.Green : IndicatorEnum.State.Red;
                case IndicatorEnum.ComparisonValueType.OffLimits:
                    return lowerValueComparison < 0 && higherValueComparison > 0 ? IndicatorEnum.State.Green : IndicatorEnum.State.Red;
                default:
                    throw new InvalidOperationException("Indicator comparison type is not correct");
            }
        }

        private IndicatorEnum.State CalculateSingleValueBasedState<T>(Indicator indicator, IndicatorMeasure lastMeasure) where T : IComparable
        {
            var recordValue = lastMeasure.Record as SingleValue<T>;
            var objectiveValue = lastMeasure.Objective as SingleValue<T>;
            var comparison = recordValue.Value.CompareTo(objectiveValue.Value);
            if (recordValue == null || objectiveValue == null)
            {
                throw new InvalidOperationException("Indicator measure values are not correct");
            }

            switch (indicator.ComparisonValue)
            {
                case IndicatorEnum.ComparisonValueType.Equal:
                    return comparison == 0 ? IndicatorEnum.State.Green : IndicatorEnum.State.Red;
                case IndicatorEnum.ComparisonValueType.GreaterThan:
                    return comparison > 0 ? IndicatorEnum.State.Green : IndicatorEnum.State.Red;
                case IndicatorEnum.ComparisonValueType.SmallerThan:
                    return comparison < 0 ? IndicatorEnum.State.Green : IndicatorEnum.State.Red;
                case IndicatorEnum.ComparisonValueType.GreaterOrEqualThan:
                    return comparison >= 0 ? IndicatorEnum.State.Green : IndicatorEnum.State.Red;
                case IndicatorEnum.ComparisonValueType.SmallerOrEqualThan:
                    return comparison <= 0 ? IndicatorEnum.State.Green : IndicatorEnum.State.Red;
                default:
                    throw new InvalidOperationException("Indicator comparison type is not correct");
            }
        }
    }
}
