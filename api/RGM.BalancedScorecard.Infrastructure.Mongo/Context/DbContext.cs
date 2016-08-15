namespace RGM.BalancedScorecard.Infrastructure.Mongo.Context
{
    using MongoDB.Driver;

    public class DbContext : IDbContext
    {
        public DbContext()
        {
            this.Client = new MongoClient("mongodb://localhost:27017");
        }

        public MongoClient Client { get; }

        public IMongoDatabase Database => this.Client.GetDatabase("BalancedScorecard");

        public IMongoCollection<TEntity> Collection<TEntity>() where TEntity : class
        {
            return this.Database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
    }
}
