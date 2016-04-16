// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BasePagingFilterCriteria.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the BasePagingFilterCriteria type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.SharedKernel.Infrastructure
{
    /// <summary>
    /// The base paging filter.
    /// </summary>
    public abstract class BasePagingFilterCriteria
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        public int PageSize { get; set; }
    }
}
