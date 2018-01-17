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
            var columns = Enumerable.Range(0, reader.FieldCount).Select(index => reader.GetName(index));
            if (!columns.Any(column => column.Equals("Snapshot")))
            {
                throw new InvalidOperationException("Snapshot column not found");
            }

            if (!columns.Any(column => column.Equals("Version")))
            {
                throw new InvalidOperationException("Version column not found");
            }

            var entity = JsonConvert.DeserializeObject<TEntity>((string)reader["Snapshot"]);
            entity.SetVersion((int)reader["Version"]);

            return entity;
        }
    }
}
