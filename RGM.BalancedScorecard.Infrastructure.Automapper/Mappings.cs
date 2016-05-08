namespace RGM.BalancedScorecard.Infrastructure.Automapper
{
    using AutoMapper;

    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Query.Model.Indicators;

    public static class Mappings
    {
        public static MapperConfiguration Configuration { get; set; }

        public static void Register()
        {
            Configuration = new MapperConfiguration(
                cfg =>
                    {
                        cfg.CreateMap<Indicator, IndicatorViewModel>(); 
                    });
        }
    }
}
