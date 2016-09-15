// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AggregateDescendant.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the AggregateDescendant type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.SharedKernel.Domain.Model
{
    /// <summary>
    /// The aggregate descendant.
    /// </summary>
    /// <typeparam name="TKey">Type of the key
    /// </typeparam>
    public abstract class AggregateDescendant<TKey> : DomainEntity<TKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateDescendant{TKey}"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        protected AggregateDescendant(TKey id)
            : base(id)
        {
        }

        protected AggregateDescendant() { }

        /// <summary>
        /// Gets the state.
        /// </summary>
        public Enums.Enums.State State { get; private set; }

        /// <summary>
        /// The set state.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        protected void SetState(Enums.Enums.State state)
        {
            this.State = state;
        }
    }
}
