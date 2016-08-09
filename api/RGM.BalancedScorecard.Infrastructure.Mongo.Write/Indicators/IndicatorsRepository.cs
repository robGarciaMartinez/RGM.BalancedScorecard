namespace RGM.BalancedScorecard.Infrastructure.Mongo.Write.Indicators
{
    using System;

    using MongoDB.Driver;

    using Domain.Model.Indicators;
    using Domain.Repositories;

    public class IndicatorsRepository : IIndicatorsRepository
    {
        private readonly IMongoCollection<Indicator> collection;

        public IndicatorsRepository(IMongoDatabase database)
        {
            this.collection = database.GetCollection<Indicator>("Indicators");
        }

        public Indicator FindByKey(Guid id)
        {
            return this.collection.Find(i => i.Id == id).FirstOrDefault();
        }

        public Indicator FindByCode(string code)
        {
            return this.collection.Find(i => i.Code == code).FirstOrDefault();
        }

        public void Insert(Indicator indicator)
        {
            this.collection.InsertOne(indicator);
        }

        public void Update(Indicator indicator)
        {
            this.collection.FindOneAndReplace(i => i.Id == indicator.Id, indicator);
        }

        public void Delete(Guid id)
        {
            this.collection.DeleteOne(i => i.Id == id);
        }
    }
}
