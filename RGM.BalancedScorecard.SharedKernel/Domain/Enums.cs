// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Enums.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the Enums type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.SharedKernel.Domain
{
    /// <summary>
    /// The class containing the enumerates.
    /// </summary>
    public static class Enums
    {
        /// <summary>
        /// The state.
        /// </summary>
        public enum State
        {
            /// <summary>
            /// The unchanged.
            /// </summary>
            Unchanged = 0,

            /// <summary>
            /// The added.
            /// </summary>
            Added = 1,

            /// <summary>
            /// The modified.
            /// </summary>
            Modified = 2,

            /// <summary>
            /// The deleted.
            /// </summary>
            Deleted = 3
        }
    }
}
