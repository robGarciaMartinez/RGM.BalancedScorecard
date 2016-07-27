namespace RGM.BalancedScorecard.Infrastructure.Mongo.Write.Indicators
{
    using System;

    using MongoDB.Driver;

    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Domain.Repositories;
    using RGM.BalancedScorecard.SharedKernel.Guard;

    public class IndicatorsRepository : IIndicatorsRepository
    {
        private readonly IMongoCollection<Indicator> collection;

        public IndicatorsRepository(IMongoDatabase database)
        {
            this.collection = database.GetCollection<Indicator>("Indicators");
        }

        public IIndicator FindByKey(Guid id)
        {
            return this.collection.Find(i => i.Id == id).FirstOrDefault();
        }

        public IIndicator FindByCode(string code)
        {
            return this.collection.Find(i => i.Code == code).FirstOrDefault();
        }

        public void Insert(IIndicator indicator)
        {
            var imp = indicator as Indicator;
            Guard.AgainstNullReference(imp, "Provided parameter is not of type Indicator");
            this.collection.InsertOne(imp);
        }

        public void Update(IIndicator indicator)
        {
            var imp = indicator as Indicator;
            Guard.AgainstNullReference(imp, "Provided parameter is not of type Indicator");
            this.collection.FindOneAndReplace(i => i.Id == imp.Id, imp);
        }

        public void Delete(Guid id)
        {
            this.collection.DeleteOne(i => i.Id == id);
        }
    }
}
