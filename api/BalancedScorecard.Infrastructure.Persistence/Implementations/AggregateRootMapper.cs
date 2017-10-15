using BalancedScorecard.Infrastructure.Persistence.Abstractions;
using BalancedScorecard.Kernel.Domain;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace BalancedScorecard.Infrastructure.Persistence.Implementations
{
    public class AggregateRootMapper<TEntity> : IMapper<TEntity> where TEntity : IAggregateRoot
    {
        public TEntity Map(SqlDataReader reader)
        {
            if (Enumerable.Range(0, reader.FieldCount).Select(index => reader.GetName(index)).Any(column => column.Equals("Snapshot")))
            {
                return JsonConvert.DeserializeObject<TEntity>((string)reader["Snapshot"]);
            }

            throw new InvalidOperationException("Snapshot column not found");
        }
    }
}
