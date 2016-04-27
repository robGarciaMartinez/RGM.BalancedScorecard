using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.Infrastructure.Mongo.Indicators
{
    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Domain.Repositories;

    public class IndicatorsRepository : IIndicatorsRepository
    {
        public IndicatorSi FindByKey(Guid id)
        {
            throw new NotImplementedException();
        }

        public Guid Insert(IndicatorSi domainEntity)
        {
            throw new NotImplementedException();
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
