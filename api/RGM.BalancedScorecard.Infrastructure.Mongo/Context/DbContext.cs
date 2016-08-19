namespace RGM.BalancedScorecard.Infrastructure.Mongo.Context
{
    using Microsoft.Extensions.Configuration;

    using MongoDB.Driver;

    public class DbContext : IDbContext
    {
        private readonly IConfiguration configuration;

        public DbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Client = new MongoClient(configuration.GetValue<string>("MongoDB:Server"));
        }

        public MongoClient Client { get; }

        public IMongoDatabase Database
            => this.Client.GetDatabase(this.configuration.GetValue<string>("MongoDB:Database"));

        public IMongoCollection<TEntity> Collection<TEntity>() where TEntity : class
        {
            return this.Database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
    }
}