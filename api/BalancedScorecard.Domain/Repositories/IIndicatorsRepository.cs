using BalancedScorecard.Domain.Model.Indicators;
using System;

namespace BalancedScorecard.Domain.Repositories
{
    public interface IIndicatorsRepository 
    {
        Indicator FindByCode(string code);

        Indicator FindByKey(Guid id);

        void Insert(Indicator indicator);

        void Update(Indicator indicator);

        void Delete(Guid id);
    }
}