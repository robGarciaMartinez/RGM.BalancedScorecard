namespace RGM.BalancedScorecard.Domain.Model.Indicators.Values
{
    public class SingleValue<TValue> : IValue
    {
        public SingleValue(TValue value)
        {
            this.Value = value;
        }

        public TValue Value { get; private set; }
    }
}
