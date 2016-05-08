namespace RGM.BalancedScorecard.Infrastructure.Mongo.Write
{
    using System;

    using MongoDB.Bson.Serialization;

    using RGM.BalancedScorecard.SharedKernel.Domain.Model;

    public static class MongoCollectionsMap
    {
        public static void Register()
        {
            BsonClassMap.RegisterClassMap<AggregateRoot<Guid>>(map => map.UnmapProperty(i => i.Events));
        }
    }
}
