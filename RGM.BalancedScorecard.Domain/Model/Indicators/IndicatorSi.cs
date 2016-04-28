namespace RGM.BalancedScorecard.Domain.Model.Indicators
{
    using System;

    using RGM.BalancedScorecard.Domain.Enums;
    using RGM.BalancedScorecard.Domain.Model.Indicators.Base;
    using RGM.BalancedScorecard.Domain.Model.Indicators.Measures;

    public class IndicatorSi : Indicator<IndicatorMeasureSingleValue<int>>
    {
        public IndicatorSi(
            string name,
            string description,
            DateTime startDate,
            string code,
            string unit,
            int periodicity,
            int comparisonValue,
            int objectValue,
            Guid indicatorTypeId,
            Guid responsibleId,
            int? fulfillmentRate,
            bool cumulative,
            Guid id)
            : base(
                name,
                description,
                startDate,
                code,
                unit,
                (IndicatorEnum.PeriodicityType)Enum.ToObject(typeof(IndicatorEnum.PeriodicityType), periodicity),
                (IndicatorEnum.ComparisonValueType)Enum.ToObject(typeof(IndicatorEnum.ComparisonValueType), comparisonValue),
                (IndicatorEnum.ObjectValueType)Enum.ToObject(typeof(IndicatorEnum.ObjectValueType), objectValue),
                indicatorTypeId,
                responsibleId,
                fulfillmentRate,
                cumulative,
                id)
        {
        }
    }
}
