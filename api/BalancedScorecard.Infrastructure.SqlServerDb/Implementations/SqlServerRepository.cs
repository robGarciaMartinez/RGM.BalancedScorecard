using BalancedScorecard.Infrastructure.SqlServerDb.Abstractions;
using BalancedScorecard.Infrastructure.SqlServerDb.Model;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Kernel.Events;
using BalancedScorecard.Kernel.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BalancedScorecard.Infrastructure.SqlServerDb.Implementations
{
    public class SqlServerRepository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
    {
        private readonly IMapper<TEntity> _mapper;
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        private readonly string _connectionString =
            @"Server=rgm.database.windows.net;Database=BalancedScorecard;User=robertogarcia;Password=23/Junio/1984;MultipleActiveResultSets=true;";

        public SqlServerRepository(
            IMapper<TEntity> mapper,
            IDomainEventDispatcher domainEventDispatcher)
        {
            _mapper = mapper;
            _domainEventDispatcher = domainEventDispatcher;
        }

        public async Task<TEntity> GetById(Guid id) 
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT * FROM Snapshots WHERE AggregateId = @aggregateId and AggregateType = @aggregateType", connection))
                {
                    command.Parameters.Add(new SqlParameter("@aggregateId", SqlDbType.UniqueIdentifier)).Value = id;
                    command.Parameters.Add(new SqlParameter("@aggregateType", SqlDbType.NVarChar)).Value = typeof(TEntity).Name;

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
            
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    int? existingVersion = await GetAggregateCurrentVersion(aggregate.Id, connection, transaction);
                    if (existingVersion.HasValue && existingVersion > currentVersion)
                    {
                        throw new ConcurrencyException("Concurrency exception");
                    }

                    await Task.WhenAll(
                        UpsertAggregateSnapshot(existingVersion.HasValue, currentVersion, aggregate, connection, transaction),
                        InsertEvents(eventsToSave, connection, transaction));
                    
                    transaction.Commit();
                }
            }

            
            await _domainEventDispatcher.DispatchDomainEvents(aggregate.Events);
            aggregate.Events.Clear();
        }

        private async Task<int?> GetAggregateCurrentVersion(Guid aggregateId, SqlConnection connection, SqlTransaction transaction)
        {
            using (var command = new SqlCommand("SELECT MAX(Version) FROM Events WHERE AggregateId = @aggregateId and AggregateType = @aggregateType", connection, transaction))
            {
                command.Parameters.Add(new SqlParameter("@aggregateId", SqlDbType.UniqueIdentifier)).Value = aggregateId;
                command.Parameters.Add(new SqlParameter("@aggregateType", SqlDbType.NVarChar)).Value = typeof(TEntity).Name;

                var result = await command.ExecuteScalarAsync();
                return result != DBNull.Value ? (int)result : default(int?);
            }
        }

        private Task UpsertAggregateSnapshot(bool isNew, int currentVersion, TEntity aggregate, SqlConnection connection, SqlTransaction transaction)
        {
            var commandText = isNew
                        ? @"UPDATE Snapshots SET Snapshot=@snapshot, Version=@version WHERE AggregateId=@aggregateId"
                        : @"INSERT INTO Snapshots(AggregateType, AggregateId, Version, Snapshot) VALUES (@aggregateType, @aggregateId, @version, @snapshot)";

            using (var command = new SqlCommand(commandText, connection, transaction))
            {
                command.Parameters.Add(new SqlParameter("@aggregateType", SqlDbType.NVarChar)).Value = typeof(TEntity).Name;
                command.Parameters.Add(new SqlParameter("@aggregateId", SqlDbType.UniqueIdentifier)).Value = aggregate.Id;
                command.Parameters.Add(new SqlParameter("@version", SqlDbType.Int)).Value = currentVersion;
                command.Parameters.Add(new SqlParameter("@snapshot", SqlDbType.NVarChar)).Value = 
                    JsonConvert.SerializeObject(
                        aggregate, 
                        new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver()});

                return command.ExecuteNonQueryAsync();
            }
        }

        private Task InsertEvents(List<EventData> eventsToSave, SqlConnection connection, SqlTransaction transaction)
        {
            var tasks = new List<Task>(eventsToSave.Count);
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

            return Task.WhenAll(tasks);
        }
    }
}
