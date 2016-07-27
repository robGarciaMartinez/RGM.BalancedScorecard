namespace RGM.BalancedScorecard.Domain.Model.Indicators
{
    using RGM.BalancedScorecard.Domain.Services.Interfaces;
    using RGM.BalancedScorecard.SharedKernel.Domain.Model;

    public interface IIndicator : IAggregateRoot
    {
        void Create(IIndicatorStateCalculator stateCalculator);
    }
}
