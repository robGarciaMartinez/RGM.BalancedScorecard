namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using MongoDB.Driver;

    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Domain.Model.Indicators.Base;
    using RGM.BalancedScorecard.Domain.Model.Objectives;

    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost:27017");

            var mongoDb = client.GetDatabase("BalancedScorecard");

            var collection = mongoDb.GetCollection<BaseIndicator>("Indicators");

            //BsonClassMap.RegisterClassMap<BaseIndicator>();
            BsonClassMap.RegisterClassMap<IndicatorSi>();
            BsonClassMap.RegisterClassMap<IndicatorDi>();
            BsonClassMap.RegisterClassMap<Objective>();

            //BsonClassMap.RegisterClassMap<BaseIndicator>(map => map.);

            //var guid = Guid.NewGuid();

            //var filter = Builders<IndicatorSi>.Filter.In(i => i.Id);

            //var indicator = new IndicatorSi(
            //    "Name 1",
            //    "Description 1",
            //    DateTime.Today,
            //    "Code",
            //    "£",
            //    IndicatorEnum.PeriodicityType.Month,
            //    IndicatorEnum.ComparisonValueType.Greater,
            //    IndicatorEnum.ObjectValueType.Decimal,
            //    Guid.NewGuid(),
            //    Guid.NewGuid(),
            //    75,
            //    true,
            //    Guid.NewGuid());

            //var measure1 = new IndicatorMeasure<IndicatorMeasureSingleValue<int>>(
            //    DateTime.Today,
            //    new IndicatorMeasureSingleValue<int>(15, 16),
            //    "Notes",
            //    Guid.NewGuid());

            //var measure2 = new IndicatorMeasure<IndicatorMeasureSingleValue<int>>(
            //    DateTime.Today,
            //    new IndicatorMeasureSingleValue<int>(16, 19),
            //    "Notes",
            //    Guid.NewGuid());

            //var measure3 = new IndicatorMeasure<IndicatorMeasureDoubleValue<int>>(
            //    DateTime.Today,
            //    new IndicatorMeasureDoubleValue<int>(15, 12, 17),
            //    "Notes",
            //    Guid.NewGuid());

            //indicator.Measures = new List<IndicatorMeasure<IndicatorMeasureSingleValue<int>>>()
            //                         {
            //                             measure1,
            //                             measure2
            //                         };

            //collection.InsertOne(indicator);

            //var indicator2 = new IndicatorDi(
            //    "Name 2",
            //    "Description 2",
            //    DateTime.Today,
            //    "Code",
            //    "£",
            //    IndicatorEnum.PeriodicityType.Month,
            //    IndicatorEnum.ComparisonValueType.Greater,
            //    IndicatorEnum.ObjectValueType.Decimal,
            //    Guid.NewGuid(),
            //    Guid.NewGuid(),
            //    75,
            //    true,
            //    Guid.NewGuid());

            //indicator2.Measures = new List<IndicatorMeasure<IndicatorMeasureDoubleValue<int>>> { measure3 };

            //collection.InsertOne(indicator2);

            //var indicators = collection.Find(baseIndicator => baseIndicator.Code == "Code").ToList();

            //var objective2 = new Objective(
            //    "Name1",
            //    "Description1",
            //    DateTime.Today,
            //    DateTime.Today,
            //    "Code",
            //    Guid.NewGuid(),
            //    Guid.NewGuid());

            var objectiveCollection = mongoDb.GetCollection<Objective>("Objectives");

            //objective2.Indicators = indicators.Select(i => i.Id ).ToList();

            //objectiveCollection.InsertOne(objective2);


            var filter = Builders<IndicatorSi>.Filter.Empty;
            var objective = objectiveCollection.Find(o => o.Code == "Code").FirstOrDefault();

            var indicatorIds = objective.Indicators;

            //var indicators2 = collection.Find(i => indicatorIds.Contains(i.Id)).ToList();




            //var a = objectiveCollection.Aggregate()
            //    .Lookup<BaseIndicator, object>("Indicators", new StringFieldDefinition<Objective>("Indicators.Id"), new StringFieldDefinition<BaseIndicator>("Id"), new StringFieldDefinition<object>("lala"));
        }
    }
}   