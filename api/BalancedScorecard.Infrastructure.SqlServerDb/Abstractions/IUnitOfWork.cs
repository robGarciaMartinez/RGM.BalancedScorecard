using System.Threading.Tasks;

namespace BalancedScorecard.Infrastructure.SqlServerDb.Abstractions
{
    public interface IUnitOfWork
    {
        Task CommitChanges();
    }
}
