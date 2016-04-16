// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the IRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.SharedKernel.Domain
{
    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="TDomain">Type of domain object
    /// </typeparam>
    /// <typeparam name="TKey">Type of the aggregate key
    /// </typeparam>
    public interface IRepository<TDomain, TKey> where TDomain : IAggregateRoot
    {
        /// <summary>
        /// The find by key.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TDomain"/>.
        /// </returns>
        TDomain FindByKey(TKey id);

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="domainEntity">
        /// The aggregate root.
        /// </param>
        /// <returns>
        /// The <see cref="TKey"/>.
        /// </returns>
        TKey Insert(TDomain domainEntity);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="domainEntity">
        /// The aggregate root.
        /// </param>
        void Update(TDomain domainEntity);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void Delete(TKey id);
    }
}
