using Microsoft.Extensions.Configuration;
using RGM.BalancedScorecard.EF.Abstractions;
using RGM.BalancedScorecard.EF.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.Infrastructure.WriteDb.Implementations
{
    public class DbContext : IDbContext
    {
        private readonly string _connectionString;

        public DbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings:WriteDatabase").Value;
        }

        public async Task ExecuteNonQueryAsync(string sqlText, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sqlText, connection))
            {
                await connection.OpenAsync();
                command.Parameters.AddRange(parameters);
                command.CommandType = CommandType.Text;

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<T> ExecuteSingleAsync<T>(string sqlText, params SqlParameter[] parameters) where T : DbEntity
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sqlText, connection))
            {
                await connection.OpenAsync();
                command.Parameters.AddRange(parameters);
                command.CommandType = CommandType.Text;

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (!reader.HasRows)
                    {
                        return default(T);
                    }
                    reader.Read();
                    var item = Activator.CreateInstance<T>();
                    var properties = typeof(T).GetProperties();
                    foreach (var property in properties)
                    {
                        if (Enumerable.Range(0, reader.FieldCount).Any(i => reader.GetName(i) == property.Name))
                        {
                            if (reader[property.Name] != DBNull.Value)
                            {
                                property.SetValue(item, reader[property.Name]);
                            }
                        }
                    }

                    return item;
                }
            }
        }
    }
}
