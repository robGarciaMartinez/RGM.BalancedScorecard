namespace RGM.BalancedScorecard.Test.Helpers.Indicators
{
    using System;

    using RGM.BalancedScorecard.Domain.Enums;
    using RGM.BalancedScorecard.Domain.Model.Indicators;

    public class MockDomainObjects
    {
        public static Indicator GetIndicator()
        {
            return new Indicator(
                "",
                "",
                DateTime.Today,
                "",
                "",
                IndicatorEnum.PeriodicityType.Month,
                IndicatorEnum.ComparisonValueType.Equal,
                IndicatorEnum.ObjectValueType.Integer,
                Guid.NewGuid(),
                Guid.NewGuid(),
                null,
                true,
                Guid.NewGuid());
        }
    }
}
