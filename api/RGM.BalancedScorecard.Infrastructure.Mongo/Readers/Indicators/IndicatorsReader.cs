namespace RGM.BalancedScorecard.Infrastructure.Mongo.Readers.Indicators
{
    using MongoDB.Driver;

    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Infrastructure.Automapper;
    using RGM.BalancedScorecard.Infrastructure.Mongo.Context;
    using RGM.BalancedScorecard.Query.Model.Indicators;
    using RGM.BalancedScorecard.Query.Readers;

    public class IndicatorsReader : IIndicatorsReader
    {
        private readonly IDbContext context;

        private readonly IMapper mapper;

        public IndicatorsReader(IDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IndicatorViewModel GetByCode(string code)
        {
            var indicator =
                this.context.Collection<Indicator>()
                    .FindSync(Builders<Indicator>.Filter.Where(i => i.Code == code))
                    .FirstOrDefault();

            return this.mapper.Map<IndicatorViewModel>(indicator);
        }
    }
}
