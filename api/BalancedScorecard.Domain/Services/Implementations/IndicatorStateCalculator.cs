using BalancedScorecard.Domain.Enums;
using BalancedScorecard.Domain.Model.Indicators;
using BalancedScorecard.Domain.Model.Indicators.Values;
using BalancedScorecard.Domain.Services.Abstractions;
using System;

namespace BalancedScorecard.Domain.Services.Implementations
{
    public class IndicatorStateCalculator : IIndicatorStateCalculator
    {
        public IndicatorEnum.Status Calculate(Indicator indicator)
        {
            if (!indicator.HasMeasures())
            {
                return IndicatorEnum.Status.Grey;
            }

            var lastMeasure = indicator.GetLastMeasure();
            if (lastMeasure.Date.AddMonths((int)indicator.PeriodicityType) < DateTime.Today)
            {
                return IndicatorEnum.Status.Grey;
            }

            switch (indicator.IndicatorValueType)
            {
                case IndicatorEnum.IndicatorValueType.Integer:
                    return CalculateState<int>(indicator, lastMeasure);
                case IndicatorEnum.IndicatorValueType.Decimal:
                    return CalculateState<decimal>(indicator, lastMeasure);
                case IndicatorEnum.IndicatorValueType.Boolean:
                    return CalculateState<bool>(indicator, lastMeasure);
                default:
                    throw new InvalidOperationException("Indicator measure type is not correct");
            }
        }

        private IndicatorEnum.Status CalculateState<T>(Indicator indicator, IndicatorMeasure lastMeasure) where T : IComparable
        {
            switch (indicator.ComparisonType)
            {
                case IndicatorEnum.ComparisonType.Equal:
                case IndicatorEnum.ComparisonType.NotEqual:
                case IndicatorEnum.ComparisonType.GreaterThan:
                case IndicatorEnum.ComparisonType.SmallerThan:
                case IndicatorEnum.ComparisonType.GreaterOrEqualThan:
                case IndicatorEnum.ComparisonType.SmallerOrEqualThan:
                    return CalculateSingleValueBasedState<T>(indicator, lastMeasure);
                case IndicatorEnum.ComparisonType.BetweenLimits:
                case IndicatorEnum.ComparisonType.OffLimits:
                    return CalculateDoubleValueBasedState<T>(indicator, lastMeasure);
                default:
                    throw new InvalidOperationException("Indicator measure comparison value is not correct");
            }
        }

        private IndicatorEnum.Status CalculateDoubleValueBasedState<T>(Indicator indicator, IndicatorMeasure lastMeasure) where T : IComparable
        {
            var recordValue = lastMeasure.Record as SingleValue<T>;
            var objectiveValue = lastMeasure.Objective as DoubleValue<T>;
            var lowerValueComparison = recordValue.Value.CompareTo(objectiveValue.LowerValue);
            var higherValueComparison = recordValue.Value.CompareTo(objectiveValue.HigherValue);
            if (recordValue == null || objectiveValue == null)
            {
                throw new InvalidOperationException("Indicator measure values are not correct");
            }

            switch (indicator.ComparisonType)
            {
                case IndicatorEnum.ComparisonType.BetweenLimits:
                    return lowerValueComparison >= 0 && higherValueComparison <= 0 ? IndicatorEnum.Status.Green : IndicatorEnum.Status.Red;
                case IndicatorEnum.ComparisonType.OffLimits:
                    return lowerValueComparison < 0 && higherValueComparison > 0 ? IndicatorEnum.Status.Green : IndicatorEnum.Status.Red;
                default:
                    throw new InvalidOperationException("Indicator comparison type is not correct");
            }
        }

        private IndicatorEnum.Status CalculateSingleValueBasedState<T>(Indicator indicator, IndicatorMeasure lastMeasure) where T : IComparable
        {
            var recordValue = lastMeasure.Record as SingleValue<T>;
            var objectiveValue = lastMeasure.Objective as SingleValue<T>;
            var comparison = recordValue.Value.CompareTo(objectiveValue.Value);
            if (recordValue == null || objectiveValue == null)
            {
                throw new InvalidOperationException("Indicator measure values are not correct");
            }

            switch (indicator.ComparisonType)
            {
                case IndicatorEnum.ComparisonType.Equal:
                    return comparison == 0 ? IndicatorEnum.Status.Green : IndicatorEnum.Status.Red;
                case IndicatorEnum.ComparisonType.GreaterThan:
                    return comparison > 0 ? IndicatorEnum.Status.Green : IndicatorEnum.Status.Red;
                case IndicatorEnum.ComparisonType.SmallerThan:
                    return comparison < 0 ? IndicatorEnum.Status.Green : IndicatorEnum.Status.Red;
                case IndicatorEnum.ComparisonType.GreaterOrEqualThan:
                    return comparison >= 0 ? IndicatorEnum.Status.Green : IndicatorEnum.Status.Red;
                case IndicatorEnum.ComparisonType.SmallerOrEqualThan:
                    return comparison <= 0 ? IndicatorEnum.Status.Green : IndicatorEnum.Status.Red;
                default:
                    throw new InvalidOperationException("Indicator comparison type is not correct");
            }
        }
    }
}
