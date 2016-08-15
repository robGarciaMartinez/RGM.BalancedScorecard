﻿namespace RGM.BalancedScorecard.Infrastructure.Mongo
{
    using System;

    using MongoDB.Bson.Serialization;

    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.SharedKernel.Domain.Model;

    public static class MongoCollectionsMap
    {
        public static void Register()
        {
            SetBaseClassesNotMappedProperties();
        }

        private static void SetBaseClassesNotMappedProperties()
        {
            BsonClassMap.RegisterClassMap<AggregateRoot<Guid>>(map => map.UnmapProperty(i => i.Events));
            BsonClassMap.RegisterClassMap<AggregateDescendant<Guid>>(map => map.UnmapProperty(i => i.State));
        }
    }
}
