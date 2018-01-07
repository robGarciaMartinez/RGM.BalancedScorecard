using System;

namespace BalancedScorecard.Domain.Model.Indicators.Values
{
    public class DoubleValue<TValue> : IIndicatorValue
        where TValue : IComparable
    {
        public DoubleValue(TValue lowerValue, TValue higherValue)
        {
            LowerValue = lowerValue;
            HigherValue = higherValue;
        }

        public TValue LowerValue { get; private set; }

        public TValue HigherValue { get; private set; }
    }
}
