namespace RGM.BalancedScorecard.Domain.Repositories
{
    using System;

    using RGM.BalancedScorecard.Domain.Model.Indicators;

    public interface IIndicatorsRepository 
    {
        Indicator FindByCode(string code);

        Indicator FindByKey(Guid id);

        void Insert(Indicator indicator);

        void Update(Indicator indicator);

        void Delete(Guid id);
    }
}