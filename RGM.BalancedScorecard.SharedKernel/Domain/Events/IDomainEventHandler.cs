// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDomainEventHandler.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the IDomainEventHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.SharedKernel.Domain.Events
{
    /// <summary>
    /// The DomainEventHandler interface.
    /// </summary>
    /// <typeparam name="TEvent">Type of the event
    /// </typeparam>
    public interface IDomainEventHandler<in TEvent> 
        where TEvent : class, IDomainEvent
    {
        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        void Handle(TEvent e);
    }
}
