using System;
using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Domain
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetEntityById(Guid id);

        void InsertEntity(TEntity entity);
    }
}
