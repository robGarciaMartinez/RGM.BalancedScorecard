namespace RGM.BalancedScorecard.Infrastructure.Automapper
{
    public interface IMapper
    {
        TDestination Map<TDestination>(object source);
    }
}
