using MongoDB.Driver;
using RGM.BalancedScorecard.Domain.Model.Indicators;
using RGM.BalancedScorecard.Domain.Repositories;
using RGM.BalancedScorecard.Infrastructure.MongoDb.Context;
using System;

namespace RGM.BalancedScorecard.Infrastructure.MongoDb.Repositories.Indicators
{
    public class IndicatorsRepository : IIndicatorsRepository
    {
        private readonly IDbContext context;

        public IndicatorsRepository(IDbContext context)
        {
            this.context = context;
        }

        public Indicator FindByKey(Guid id)
        {
            return
                this.context.Collection<Indicator>()
                    .FindSync<Indicator>(Builders<Indicator>.Filter.Where(i => i.Id == id))
                    .FirstOrDefault();
        }

        public Indicator FindByCode(string code)
        {
            return
                this.context.Collection<Indicator>()
                    .FindSync<Indicator>(Builders<Indicator>.Filter.Where(i => i.Code == code))
                    .FirstOrDefault();
        }

        public void Insert(Indicator indicator)
        {
            this.context.Collection<Indicator>().InsertOne(indicator);
        }

        public void Update(Indicator indicator)
        {
            this.context.Collection<Indicator>()
                .FindOneAndReplace(Builders<Indicator>.Filter.Where(i => i.Id == indicator.Id), indicator);
        }

        public void Delete(Guid id)
        {
            this.context.Collection<Indicator>().DeleteOne(Builders<Indicator>.Filter.Where(i => i.Id == id));
        }
    }
}