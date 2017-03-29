using RGM.BalancedScorecard.EF.Model;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.EF.Abstractions
{
    public interface IDbContext
    {
        Task ExecuteNonQueryAsync(string sqlText, params SqlParameter[] parameters);

        Task<T> ExecuteSingleAsync<T>(string sqlText, params SqlParameter[] parameters) where T : DbEntity;
    }
}
