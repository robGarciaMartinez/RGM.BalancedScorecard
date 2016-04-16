// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIndicatorService.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the IIndicatorService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.ApplicationServices.Services.Interfaces
{
    using System;

    using ViewModels.Indicator;

    /// <summary>
    /// The IndicatorService interface.
    /// </summary>
    public interface IIndicatorService
    {
        /// <summary>
        /// The create indicator.
        /// </summary>
        /// <param name="inputModel">
        /// The input model.
        /// </param>
        /// <returns>
        /// The <see cref="Guid"/>.
        /// </returns>
        Guid CreateIndicator(CreateIndicatorVm inputModel);

        /// <summary>
        /// The update indicator.
        /// </summary>
        /// <param name="inputModel">
        /// The input model.
        /// </param>
        void UpdateIndicator(EditIndicatorVm inputModel);

        /// <summary>
        /// The get indicator by code.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <returns>
        /// The <see cref="EditIndicatorVm"/>.
        /// </returns>
        EditIndicatorVm GetIndicatorByCode(string code);
    }
}