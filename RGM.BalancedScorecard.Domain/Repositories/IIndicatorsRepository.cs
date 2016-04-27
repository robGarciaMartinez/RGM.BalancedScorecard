// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIndicatorsRepository.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the IIndicatorsRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.Domain.Repositories
{
    using System;

    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.SharedKernel.Domain.Repositories;

    /// <summary>
    ///     The IndicatorsRepository interface.
    /// </summary>
    public interface IIndicatorsRepository : IRepository<IndicatorSi, Guid>
    {
    }
}