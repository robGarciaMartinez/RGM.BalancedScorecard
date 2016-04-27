namespace RGM.BalancedScorecard.Domain.Model.Indicators.Measures
{
    public class IndicatorMeasureValue<TValueType>
    {
        public IndicatorMeasureValue(TValueType recordValue)
        {
            this.RecordValue = recordValue;
        }

        public TValueType RecordValue { get; protected set; }
    }
}