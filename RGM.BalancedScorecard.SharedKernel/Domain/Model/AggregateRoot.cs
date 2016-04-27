// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AggregateRoot.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the AggregateRoot type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.SharedKernel.Domain.Model
{
    using System.Collections.Generic;

    using RGM.BalancedScorecard.SharedKernel.Domain.Events;

    /// <summary>
    /// The aggregate root.
    /// </summary>
    /// <typeparam name="TKey">Type of the key
    /// </typeparam>
    public abstract class AggregateRoot<TKey> : DomainEntity<TKey>, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot{TKey}"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        protected AggregateRoot(TKey id)
            : base(id)
        {
        }

        protected AggregateRoot()
        {
        }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        public List<IDomainEvent> Events { get; protected set; } 
    }
}
