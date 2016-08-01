namespace RGM.BalancedScorecard.Infrastructure.Automapper
{
    using AutoMapper;

    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Query.Model.Indicators;

    public static class Mappings
    {
        private static MapperConfiguration configuration;

        public static MapperConfiguration Configuration
        {
            get
            {
                return configuration
                       ?? (configuration =
                           new MapperConfiguration(cfg => { cfg.CreateMap<Indicator, IndicatorViewModel>(); }));
            }
        }
    }
}
