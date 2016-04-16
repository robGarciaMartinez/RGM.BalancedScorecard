// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseSearchResult.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the BaseSearchResult type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.SharedKernel.Infrastructure
{
    using System.Collections.Generic;

    /// <summary>
    /// The base search result.
    /// </summary>
    /// <typeparam name="TDomain">Type of the domain object
    /// </typeparam>
    public abstract class BaseSearchResult<TDomain>
    {
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        public IEnumerable<TDomain> Results { get; set; }
    }
}   
