// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndicatorEnum.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the Enum type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.Domain.Indicator
{
    /// <summary>
    /// The class with indicator's enumerates.
    /// </summary>
    public static class IndicatorEnum
    {
        /// <summary>
        /// The periodicity type.
        /// </summary>
        public enum PeriodicityType
        {
            /// <summary>
            /// The month.
            /// </summary>
            Month = 1,

            /// <summary>
            /// The two month.
            /// </summary>
            TwoMonth = 2,

            /// <summary>
            /// The three month.
            /// </summary>
            ThreeMonth = 3,

            /// <summary>
            /// The four month.
            /// </summary>
            FourMonth = 4,

            /// <summary>
            /// The six month.
            /// </summary>
            SixMonth = 6,

            /// <summary>
            /// The twelve month.
            /// </summary>
            TwelveMonth = 12
        }

        /// <summary>
        /// The comparison value type.
        /// </summary>
        public enum ComparisonValueType
        {
            /// <summary>
            /// The greater.
            /// </summary>
            Greater = 1,

            /// <summary>
            /// The smaller.
            /// </summary>
            Smaller = 2,

            /// <summary>
            /// The equal.
            /// </summary>
            Equal = 3
        }

        /// <summary>
        /// The object value type.
        /// </summary>
        public enum ObjectValueType
        {
            /// <summary>
            /// The integer.
            /// </summary>
            Integer = 1,

            /// <summary>
            /// The decimal.
            /// </summary>
            Decimal = 2,

            /// <summary>
            /// The boolean.
            /// </summary>
            //Boolean = 3
        }

        /// <summary>
        /// The state.
        /// </summary>
        public enum State
        {
            /// <summary>
            /// The grey.
            /// </summary>
            Grey,

            /// <summary>
            /// The green.
            /// </summary>
            Green,

            /// <summary>
            /// The yellow.
            /// </summary>
            Yellow,

            /// <summary>
            /// The red.
            /// </summary>
            Red
        }
    }
}
