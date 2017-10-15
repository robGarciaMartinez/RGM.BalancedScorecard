using BalancedScorecard.Infrastructure.Persistence.Abstractions;
using BalancedScorecard.Kernel.Domain;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BalancedScorecard.Infrastructure.Persistence.Implementations
{
    public class SqlServerRepository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
    {
        private IMapper<TEntity> _mapper;
        private readonly IConfiguration _configuration;

        public SqlServerRepository(
            IMapper<TEntity> mapper,
            IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<TEntity> GetById(Guid id) 
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("WriteDb")))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT * FROM Snapshots WHERE AggregateId = @aggregateId", connection))
                {
                    command.Parameters.Add(new SqlParameter("@aggregateId", SqlDbType.UniqueIdentifier)).Value = id;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return _mapper.Map(reader);
                        }

                        return default(TEntity);
                    }
                }
            }
        }

        public async Task SaveAsync(TEntity aggregate)
        {
            if (!aggregate.Events.Any())
            {
                return;
            }

            var currentVersion = aggregate.Version;
            var eventsToSave = aggregate.Events.Select(e => e.ToEventData(aggregate, ++currentVersion)).ToList();
            aggregate.Events.Clear();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("WriteDb")))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    int? existingVersion = null;
                    using (var command = new SqlCommand("SELECT MAX(Version) FROM Events WHERE AggregateId = @aggregateId", connection, transaction))
                    {
                        command.Parameters.Add(new SqlParameter("@aggregateId", SqlDbType.UniqueIdentifier)).Value = aggregate.Id;
                        var result = await command.ExecuteScalarAsync();
                        existingVersion = result != DBNull.Value ? (int)existingVersion : default(int?);
                    }

                    if (existingVersion.HasValue && existingVersion > currentVersion)
                    {
                        throw new Exception("Concurrency exception");
                    }


                    var tasks = new List<Task>(eventsToSave.Count + 1);
                    using (var command = new SqlCommand(@"INSERT INTO Snapshots(AggregateType, AggregateId, Version, Snapshot) " +
                        "VALUES(@aggregateType, @aggregateId, @version, @snapshot)", connection, transaction))
                    {
                        command.Parameters.Add(new SqlParameter("@aggregateType", SqlDbType.NVarChar)).Value = aggregate.GetType().Name;
                        command.Parameters.Add(new SqlParameter("@aggregateId", SqlDbType.UniqueIdentifier)).Value = aggregate.Id;
                        command.Parameters.Add(new SqlParameter("@version", SqlDbType.Int)).Value = currentVersion;
                        command.Parameters.Add(new SqlParameter("@snapshot", SqlDbType.NVarChar)).Value = JsonConvert.SerializeObject(aggregate);

                        tasks.Add(command.ExecuteNonQueryAsync());
                    }

                    using (var command = new SqlCommand(@"INSERT INTO Events(Id, Created, AggregateType, AggregateId, Version, Event, Metadata) " +
                        "VALUES(@id, @created, @aggregateType, @aggregateId, @version, @event, @metadata)", connection, transaction))
                    {
                        foreach (var eventToSave in eventsToSave)
                        {
                            command.Parameters.Add(new SqlParameter("@id", SqlDbType.UniqueIdentifier)).Value = eventToSave.Id;
                            command.Parameters.Add(new SqlParameter("@created", SqlDbType.DateTime)).Value = eventToSave.Created;
                            command.Parameters.Add(new SqlParameter("@aggregateType", SqlDbType.NVarChar)).Value = eventToSave.AggregateType;
                            command.Parameters.Add(new SqlParameter("@aggregateId", SqlDbType.UniqueIdentifier)).Value = eventToSave.AggregateId;
                            command.Parameters.Add(new SqlParameter("@version", SqlDbType.Int)).Value = eventToSave.Version;
                            command.Parameters.Add(new SqlParameter("@event", SqlDbType.NVarChar)).Value = eventToSave.Event;
                            command.Parameters.Add(new SqlParameter("@metadata", SqlDbType.NVarChar)).Value = eventToSave.Metadata;
                        }

                        tasks.Add(command.ExecuteNonQueryAsync());
                    }

                    await Task.WhenAll(tasks);
                    transaction.Commit();
                }
            }
        }
    }
}
