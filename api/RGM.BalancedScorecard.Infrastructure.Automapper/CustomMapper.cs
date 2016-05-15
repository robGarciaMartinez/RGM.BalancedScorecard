namespace RGM.BalancedScorecard.Infrastructure.Automapper
{
    public class CustomMapper : IMapper
    {
        private readonly AutoMapper.IMapper mapper;

        public CustomMapper(AutoMapper.IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination Map<TDestination>(object source)
        {
            return this.mapper.Map<TDestination>(source);
        }
    }
}
