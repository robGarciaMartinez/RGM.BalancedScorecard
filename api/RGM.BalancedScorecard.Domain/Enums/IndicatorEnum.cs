namespace RGM.BalancedScorecard.Domain.Enums
{
    public static class IndicatorEnum
    {
        public enum ComparisonValueType
        {
            GreaterThann = 1,
            SmallerThan = 2,
            Equal = 3
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