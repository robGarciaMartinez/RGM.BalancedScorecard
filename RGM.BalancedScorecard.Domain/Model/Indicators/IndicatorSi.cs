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
            IndicatorEnum.PeriodicityType periodicity,
            IndicatorEnum.ComparisonValueType comparisonValue,
            IndicatorEnum.ObjectValueType objectValue,
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
                periodicity,
                comparisonValue,
                objectValue,
                indicatorTypeId,
                responsibleId,
                fulfillmentRate,
                cumulative,
                id)
        {
        }
    }
}
