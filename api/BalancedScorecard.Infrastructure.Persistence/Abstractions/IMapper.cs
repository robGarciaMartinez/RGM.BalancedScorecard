using BalancedScorecard.Kernel.Domain;
using System.Data.SqlClient;

namespace BalancedScorecard.Infrastructure.Persistence.Abstractions
{
    public interface IMapper<TEntity> where TEntity : IAggregateRoot
    {
        TEntity Map(SqlDataReader reader);
    }
}
