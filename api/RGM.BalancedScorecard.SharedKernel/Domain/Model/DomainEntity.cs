// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainEntity.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the DomainEntity type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.SharedKernel.Domain.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// The domain entity.
    /// </summary>
    /// <typeparam name="TKey">Type of the key
    /// </typeparam>
    public abstract class DomainEntity<TKey>
    {
        /// <summary>
        /// The _broken rules.
        /// </summary>
        private readonly List<BusinessRule> brokenRules = new List<BusinessRule>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEntity{TKey}"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        protected DomainEntity(TKey id)
        {
            this.Id = id;
        }

        protected DomainEntity()
        {
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public TKey Id { get; protected set; }
    }
}