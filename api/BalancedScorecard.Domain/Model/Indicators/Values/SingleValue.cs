using System;

namespace BalancedScorecard.Domain.Model.Indicators.Values
{
    public class SingleValue<TValue> : IIndicatorValue
        where TValue : IComparable
    {
        public SingleValue(TValue value)
        {
            Value = value;
        }

        public TValue Value { get; private set; }
    }
}
