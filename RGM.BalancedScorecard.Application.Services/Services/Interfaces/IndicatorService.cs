// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndicatorService.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the IndicatorService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.ApplicationServices.Services.Interfaces
{
    using System;

    using RGM.BalancedScorecard.ApplicationServices.ViewModels.Indicator;

    /// <summary>
    /// The indicator service.
    /// </summary>
    public class IndicatorService : IIndicatorService
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
        public Guid CreateIndicator(CreateIndicatorVm inputModel)
        {
            return new Guid();
        }

        /// <summary>
        /// The update indicator.
        /// </summary>
        /// <param name="inputModel">
        /// The input model.
        /// </param>
        public void UpdateIndicator(EditIndicatorVm inputModel)
        {
            
        }

        /// <summary>
        /// The get indicator by code.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <returns>
        /// The <see cref="EditIndicatorVm"/>.
        /// </returns>
        public EditIndicatorVm GetIndicatorByCode(string code)
        {
            return new EditIndicatorVm();
        }
    }
}
