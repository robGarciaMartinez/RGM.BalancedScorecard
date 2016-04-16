// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceEntity.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the ReferenceEntity type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.Domain.Infrastructure
{
    using System;

    using RGM.BalancedScorecard.SharedKernel.Domain;

    /// <summary>
    /// The reference entity.
    /// </summary>
    public abstract class ReferenceEntity : DomainEntity<Guid?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceEntity"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="id">
        /// The id.
        /// </param>
        protected ReferenceEntity(string name, string code, Guid? id = null) : base(id)
        {
            this.Name = name;
            this.Code = code;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the code.
        /// </summary>
        public string Code { get; }
    }
}
