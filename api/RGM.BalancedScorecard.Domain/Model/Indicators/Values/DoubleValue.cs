namespace RGM.BalancedScorecard.Domain.Model.Indicators.Values
{
    public class DoubleValue<TValue> : IValue
    {
        public DoubleValue(TValue lowerValue, TValue higherValue)
        {
            this.LowerValue = lowerValue;
            this.HigherValue = higherValue;
        }

        public TValue LowerValue { get; private set; }

        public TValue HigherValue { get; private set; }
    }
}
