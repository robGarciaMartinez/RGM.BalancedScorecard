namespace RGM.BalancedScorecard.Infrastructure.MongoDb.Context
{
    using MongoDB.Driver;

    public interface IDbContext
    {
        MongoClient Client { get; }

        IMongoDatabase Database { get; }

        IMongoCollection<TEntity> Collection<TEntity>() where TEntity : class;
    }
}
