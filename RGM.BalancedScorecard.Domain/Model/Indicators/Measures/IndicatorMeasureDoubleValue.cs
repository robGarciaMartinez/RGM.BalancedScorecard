namespace RGM.BalancedScorecard.Domain.Model.Indicators.Measures
{
    public class IndicatorMeasureDoubleValue<TValueType> : IndicatorMeasureValue<TValueType>
    {
        public IndicatorMeasureDoubleValue(
            TValueType recordValue,
            TValueType lowerTargetValue,
            TValueType higherTargetValue)
            : base(recordValue)
        {
            this.LowerTargetValue = lowerTargetValue;
            this.HigherTargetValue = higherTargetValue;
        }

        public TValueType LowerTargetValue { get; private set; }

        public TValueType HigherTargetValue { get; private set; }
    }
}