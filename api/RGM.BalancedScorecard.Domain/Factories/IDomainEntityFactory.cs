namespace RGM.BalancedScorecard.Domain.Factories
{
    public interface IDomainEntityFactory<out TDomain, in TCommand>
    {
        TDomain Create(TCommand command);
    }
}
