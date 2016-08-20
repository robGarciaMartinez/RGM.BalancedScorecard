namespace RGM.BalancedScorecard.Test.Helpers.Indicators
{
    using System;

    using RGM.BalancedScorecard.Domain.Commands.Indicators;
    using RGM.BalancedScorecard.Domain.Enums;
    using RGM.BalancedScorecard.Domain.Model.Indicators;

    public static class MockCommandObjects
    {
        public static CreateIndicatorCommand GetCreateIndicatorCommand()
        {
            return new CreateIndicatorCommand
            {
                Id = Guid.NewGuid(),
                Code = "001",
                Description = "Mock indicator description",
                Name = "Mock indicator name",
                ComparisonValue = IndicatorEnum.ComparisonValueType.Equal,
                FulfillmentRate = 75,
                IndicatorTypeId = Guid.NewGuid(),
                Unit = "£",
                Cumulative = true,
                ObjectValue = IndicatorEnum.ObjectValueType.Integer,
                Periodicity = IndicatorEnum.PeriodicityType.FourMonth,
                ResponsibleId = Guid.NewGuid(),
                StartDate = DateTime.Today
            };
        }

        public static UpdateIndicatorCommand GetUpdateIndicatorCommand()
        {
            return new UpdateIndicatorCommand
            {
                Id = Guid.NewGuid(),
                Code = "001",
                Description = "Mock indicator description",
                Name = "Mock indicator name",
                ComparisonValue = IndicatorEnum.ComparisonValueType.Equal,
                FulfillmentRate = 75,
                IndicatorTypeId = Guid.NewGuid(),
                Unit = "£",
                Cumulative = true,
                ObjectValue = IndicatorEnum.ObjectValueType.Integer,
                Periodicity = IndicatorEnum.PeriodicityType.FourMonth,
                ResponsibleId = Guid.NewGuid(),
                StartDate = DateTime.Today
            };
        }
    }
}
