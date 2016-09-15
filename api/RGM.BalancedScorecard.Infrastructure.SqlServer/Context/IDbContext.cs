using System.Data.Entity;

namespace RGM.BalancedScorecard.Infrastructure.SqlServer.Context
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
