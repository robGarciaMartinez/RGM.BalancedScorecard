// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveType.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the ObjectiveType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.Domain.Model.Objectives
{
    using System;

    using RGM.BalancedScorecard.Domain.Infrastructure;

    /// <summary>
    ///     The objective type.
    /// </summary>
    public class ObjectiveType : ReferenceEntity
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ObjectiveType" /> class.
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
        public ObjectiveType(string name, string code, Guid? id = null)
            : base(name, code, id)
        {
        }
    }
}