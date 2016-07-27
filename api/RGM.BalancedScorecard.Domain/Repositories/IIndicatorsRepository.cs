namespace RGM.BalancedScorecard.Domain.Repositories
{
    using System;

    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.SharedKernel.Domain.Repositories;

    public interface IIndicatorsRepository 
    {
        IIndicator FindByCode(string code);

        IIndicator FindByKey(Guid id);

        void Insert(IIndicator indicator);

        void Update(IIndicator indicator);

        void Delete(Guid id);
    }
}