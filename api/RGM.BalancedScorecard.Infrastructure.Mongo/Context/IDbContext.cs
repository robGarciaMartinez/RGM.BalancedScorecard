namespace RGM.BalancedScorecard.Infrastructure.Mongo.Context
{
    using MongoDB.Driver;

    public interface IDbContext
    {
        MongoClient Client { get; }

        IMongoDatabase Database { get; }

        IMongoCollection<TEntity> Collection<TEntity>() where TEntity : class;
    }
}
