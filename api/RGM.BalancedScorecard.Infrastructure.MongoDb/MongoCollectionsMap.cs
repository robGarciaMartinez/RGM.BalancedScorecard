namespace RGM.BalancedScorecard.Infrastructure.MongoDb
{
    using System;

    using MongoDB.Bson.Serialization;

    using Domain.Model.Indicators;
    using SharedKernel.Domain.Model;
    using Domain.Model.Indicators.Values;
    using Discriminators;

    public static class MongoCollectionsMap
    {
        public static void Register()
        {
            BsonClassMap.RegisterClassMap<Indicator>();
            BsonClassMap.RegisterClassMap<IndicatorMeasure>();

            BsonSerializer.RegisterDiscriminatorConvention(typeof(IIndicatorValue), new IndicatorValueDiscriminator());
            BsonSerializer.RegisterDiscriminatorConvention(typeof(SingleValue<int>), new IndicatorValueDiscriminator());
            BsonSerializer.RegisterDiscriminatorConvention(typeof(SingleValue<float>), new IndicatorValueDiscriminator());
            BsonSerializer.RegisterDiscriminatorConvention(typeof(SingleValue<bool>), new IndicatorValueDiscriminator());
            BsonSerializer.RegisterDiscriminatorConvention(typeof(DoubleValue<int>), new IndicatorValueDiscriminator());
            BsonSerializer.RegisterDiscriminatorConvention(typeof(DoubleValue<float>), new IndicatorValueDiscriminator());
            BsonSerializer.RegisterDiscriminatorConvention(typeof(DoubleValue<bool>), new IndicatorValueDiscriminator());

            SetBaseClassesNotMappedProperties();
        }

        private static void SetBaseClassesNotMappedProperties()
        {
            BsonClassMap.RegisterClassMap<AggregateRoot<Guid>>(map => map.UnmapProperty(i => i.Events));
            BsonClassMap.RegisterClassMap<AggregateDescendant<Guid>>(map => map.UnmapProperty(i => i.State));
        }
    }
}
