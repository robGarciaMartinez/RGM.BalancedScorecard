namespace RGM.BalancedScorecard.Infrastructure.Automapper
{
    using System.Diagnostics;

    public interface IMapper
    {
        TDestination Map<TDestination>(object source);
    }
}
