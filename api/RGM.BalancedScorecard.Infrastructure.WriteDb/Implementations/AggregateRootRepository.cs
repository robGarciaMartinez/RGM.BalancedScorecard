using Newtonsoft.Json;
using RGM.BalancedScorecard.Domain.Services.Abstractions;
using RGM.BalancedScorecard.EF.Abstractions;
using RGM.BalancedScorecard.EF.Model;
using RGM.BalancedScorecard.Kernel.Domain.Model;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.EF.Implementations
{
    public class AggregateRootRepository<TAggregateRoot> : IAggregateRootRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        private readonly IDbContext _dbContext;

        public AggregateRootRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TAggregateRoot> GetAggregateRoot(Guid id)
        {
            var dbEntity = 
                await _dbContext.ExecuteSingleAsync<DbEntity>(
                    $"SELECT * FROM dbo.{typeof(TAggregateRoot).Name} WHERE Id = @id;",
                    new SqlParameter("id", id));

            return JsonConvert.DeserializeObject<TAggregateRoot>(dbEntity.SerializedObject);
        }

        public Task Insert(TAggregateRoot aggregateRoot, string requestedBy)
        {
            return _dbContext.ExecuteNonQueryAsync(
                $"INSERT INTO dbo.{typeof(TAggregateRoot).Name} (Id, SerializedObject, CreatedOn, CreatedBy) VALUES (@id, @serializedObject, @createdOn, @createdBy)",
                new SqlParameter[]
                {
                    new SqlParameter("id", aggregateRoot.Id),
                    new SqlParameter("serializedObject", JsonConvert.SerializeObject(aggregateRoot)),
                    new SqlParameter("createdOn", DateTime.Now),
                    new SqlParameter("createdBy", requestedBy)
                });
        }

        public Task Save(TAggregateRoot aggregateRoot, string requestedBy)
        {
            return _dbContext.ExecuteNonQueryAsync(
                $"UPDATE dbo.{typeof(TAggregateRoot).Name} SET SerializedObject = @serializedObject, UpdatedOn = @updatedOn, UpdatedBy = @updatedBy WHERE Id = @id;",
                new SqlParameter[]
                {
                    new SqlParameter("serializedObject", JsonConvert.SerializeObject(aggregateRoot)),
                    new SqlParameter("updatedOn", DateTime.Now),
                    new SqlParameter("updatedBy", requestedBy),
                    new SqlParameter("id", aggregateRoot.Id)
                });
        }
    }
}
