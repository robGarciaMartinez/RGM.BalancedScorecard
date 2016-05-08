namespace RGM.BalancedScorecard.Infrastructure.Mongo
{
    using MongoDB.Bson.Serialization;

    using RGM.BalancedScorecard.Domain.Model.Indicators;

    public static class MongoCollectionsMap
    {
        public static void Register()
        {
            BsonClassMap.RegisterClassMap<Indicator>();
        }
    }
}
