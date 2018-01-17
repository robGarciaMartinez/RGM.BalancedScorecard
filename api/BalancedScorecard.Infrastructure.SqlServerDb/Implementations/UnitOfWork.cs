using System.Threading.Tasks;
using BalancedScorecard.Infrastructure.SqlServerDb.Abstractions;

namespace BalancedScorecard.Infrastructure.SqlServerDb.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {

        }

        public Task CommitChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}
