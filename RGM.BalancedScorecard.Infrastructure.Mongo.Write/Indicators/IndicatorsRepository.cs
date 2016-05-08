namespace RGM.BalancedScorecard.Infrastructure.Mongo.Write.Indicators
{
    using System;

    using MongoDB.Driver;

    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Domain.Repositories;

    public class IndicatorsRepository : IIndicatorsRepository
    {
        private readonly IMongoCollection<Indicator> collection;

        public IndicatorsRepository(IMongoDatabase database)
        {
            this.collection = database.GetCollection<Indicator>("Indicators");
        }

        public Indicator FindByKey(Guid id)
        {
            return null;
        }

        public void Insert(Indicator domainEntity)
        {
            this.collection.InsertOne(domainEntity);
        }

        public void Update(Indicator domainEntity)
        {
            
        }

        public void Delete(Guid id)
        {
            
        }
    }
}
