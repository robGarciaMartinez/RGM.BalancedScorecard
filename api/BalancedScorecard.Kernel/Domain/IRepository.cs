using System;
using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Domain
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        Task<TEntity> GetById(Guid id);

        Task SaveAsync(TEntity aggregate);
    }
}
