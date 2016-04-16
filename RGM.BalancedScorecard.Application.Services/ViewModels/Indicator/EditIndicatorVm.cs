// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditIndicatorVm.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the EditIndicatorVm type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.ApplicationServices.ViewModels.Indicator
{
    using System;

    /// <summary>
    /// The edit indicator view model.
    /// </summary>
    public class EditIndicatorVm : IViewModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the updater id.
        /// </summary>
        public Guid UpdaterId { get; set; }
    }
}
