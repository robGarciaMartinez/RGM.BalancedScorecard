namespace RGM.BalancedScorecard.Infrastructure.SqlServer.Repositories.Indicators
{
    using System;

    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Domain.Repositories;
    using Context;
    using System.Linq;

    public class IndicatorsRepository : IIndicatorsRepository
    {
        private readonly IDbContext context;

        public IndicatorsRepository(IDbContext context)
        {
            this.context = context;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Indicator FindByCode(string code)
        {
            return this.context.Set<Indicator>().FirstOrDefault(i => i.Code == code);
        }

        public Indicator FindByKey(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Indicator indicator)
        {
            throw new NotImplementedException();
        }

        public void Update(Indicator indicator)
        {
            throw new NotImplementedException();
        }
    }
}