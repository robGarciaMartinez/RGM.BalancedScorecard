// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEventDispatcher.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the IEventDispatcher type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.SharedKernel.Domain
{
    /// <summary>
    /// The EventDispatcher interface.
    /// </summary>
    public interface IEventDispatcher
    {
        /// <summary>
        /// The dispatch.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        /// <typeparam name="TEvent">Type of the event
        /// </typeparam>
        void Dispatch<TEvent>(TEvent e) where TEvent : class, IDomainEvent;
    }
}
