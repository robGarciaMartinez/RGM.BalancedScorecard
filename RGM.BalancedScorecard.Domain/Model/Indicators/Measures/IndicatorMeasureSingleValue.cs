namespace RGM.BalancedScorecard.Domain.Model.Indicators.Measures
{
    public class IndicatorMeasureSingleValue<TValueType> : IndicatorMeasureValue<TValueType>
    {
        public IndicatorMeasureSingleValue(TValueType recordValue, TValueType targetValue)
            : base(recordValue)
        {
            this.TargetValue = targetValue;
        }

        public TValueType TargetValue { get; private set; }
    }
}