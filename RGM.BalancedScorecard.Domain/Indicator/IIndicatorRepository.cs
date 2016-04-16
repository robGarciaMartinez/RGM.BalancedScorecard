// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIndicatorRepository.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the IIndicatorRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.Domain.Indicator
{
    using System;

    using RGM.BalancedScorecard.Domain.Infrastructure;
    using RGM.BalancedScorecard.SharedKernel.Domain;

    /// <summary>
    /// The IndicatorRepository interface.
    /// </summary>
    public interface IIndicatorRepository : IRepository<Indicator, Guid>
    {
        /// <summary>
        /// The find by code.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <returns>
        /// The <see cref="Indicator"/>.
        /// </returns>
        Indicator FindByCode(string code);

        /// <summary>
        /// The find all.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IndicatorSearchResult"/>.
        /// </returns>
        IndicatorSearchResult FindAll(IndicatorFilterCriteria filter);
    }
}
