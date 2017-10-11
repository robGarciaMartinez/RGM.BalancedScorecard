namespace BalancedScorecard.Domain.Enums
{
    public static class IndicatorEnum
    {
        public enum ComparisonValueType
        {
            GreaterThan = 1,
            SmallerThan = 2,
            Equal = 3,
            NotEqual = 4,
            BetweenLimits = 5,
            OffLimits = 6,
            GreaterOrEqualThan = 7,
            SmallerOrEqualThan = 8
        }

        public enum ObjectValueType
        {
            Integer = 1,
            Decimal = 2,
            Boolean = 3
        }

        public enum PeriodicityType
        {
            Month = 1,
            TwoMonth = 2,
            ThreeMonth = 3,
            FourMonth = 4,
            SixMonth = 6,
            TwelveMonth = 12
        }

        public enum State
        {
            Grey,
            Blue,
            Green,
            Yellow,
            Red
        }
    }
}