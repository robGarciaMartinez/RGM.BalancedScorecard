// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndicatorType.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the IndicatorType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.Domain.Model.Indicators
{
    using System;

    using RGM.BalancedScorecard.Domain.Infrastructure;

    /// <summary>
    ///     The indicator type.
    /// </summary>
    public class IndicatorType : ReferenceEntity
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="IndicatorType" /> class.
        /// </summary>
        /// <param name="name">
        ///     The name.
        /// </param>
        /// <param name="code">
        ///     The code.
        /// </param>
        /// <param name="id">
        ///     The id.
        /// </param>
        public IndicatorType(string name, string code, Guid? id = null)
            : base(name, code, id)
        {
        }

        /// <summary>
        ///     The validate.
        /// </summary>
        protected override void Validate()
        {
        }
    }
}