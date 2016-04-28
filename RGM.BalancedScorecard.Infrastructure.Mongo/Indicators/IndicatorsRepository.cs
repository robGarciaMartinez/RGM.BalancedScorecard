using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.Infrastructure.Mongo.Indicators
{
    using MongoDB.Bson.Serialization;
    using MongoDB.Driver;

    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Domain.Model.Indicators.Base;
    using RGM.BalancedScorecard.Domain.Repositories;

    public class IndicatorsRepository : IIndicatorsRepository
    {
        private readonly IMongoCollection<BaseIndicator> collection;

        public IndicatorsRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");

            var mongoDb = client.GetDatabase("BalancedScorecard");

            this.collection = mongoDb.GetCollection<BaseIndicator>("Indicators");

            BsonClassMap.RegisterClassMap<IndicatorSi>();
        }

        public IndicatorSi FindByKey(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(IndicatorSi domainEntity)
        {
            this.collection.InsertOne(domainEntity);
        }

        public void Update(IndicatorSi domainEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
