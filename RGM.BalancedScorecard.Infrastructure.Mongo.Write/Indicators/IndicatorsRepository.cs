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
            var filter = Builders<Indicator>.Filter.Eq(i => i.Code, domainEntity.Code);
            var update =
                Builders<Indicator>.Update.Set(i => i.Name, domainEntity.Name)
                    .Set(i => i.Description, domainEntity.Description)
                    .Set(i => i.Code, domainEntity.Code)
                    .Set(i => i.StartDate, domainEntity.StartDate)
                    .Set(i => i.Unit, domainEntity.Unit)
                    .Set(i => i.IndicatorTypeId, domainEntity.IndicatorTypeId)
                    .Set(i => i.ResponsibleId, domainEntity.ResponsibleId)
                    .Set(i => i.Periodicity, domainEntity.Periodicity)
                    .Set(i => i.ComparisonValue, domainEntity.ComparisonValue)
                    .Set(i => i.ObjectValue, domainEntity.ObjectValue)
                    .Set(i => i.FulfillmentRate, domainEntity.FulfillmentRate)
                    .Set(i => i.Cumulative, domainEntity.Cumulative);

            this.collection.UpdateOne(filter, update);
        }

        public void Delete(Guid id)
        {
            
        }
    }
}
