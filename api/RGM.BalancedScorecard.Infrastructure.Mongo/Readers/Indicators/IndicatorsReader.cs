namespace RGM.BalancedScorecard.Infrastructure.Mongo.Readers.Indicators
{
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading;

    using Microsoft.Extensions.Configuration;

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

        private readonly IConfiguration configuration;

        public IndicatorsReader(IDbContext context, IMapper mapper, IConfiguration configuration)
        {
            this.context = context;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public IndicatorViewModel GetByCode(string code)
        {
            var indicator =
                this.context.Collection<Indicator>()
                    .FindSync(Builders<Indicator>.Filter.Where(i => i.Code == code))
                    .FirstOrDefault();

            return this.mapper.Map<IndicatorViewModel>(indicator);
        }

        public List<IndicatorViewModel> GetIndicators(int page)
        {
            var pageSize = this.configuration.GetValue<int>("GeneralSettings:PageSize");
            var list =
                this.context.Collection<Indicator>()
                    .Find(FilterDefinition<Indicator>.Empty)
                    .Sort(Builders<Indicator>.Sort.Descending(new StringFieldDefinition<Indicator>("StartDate")))
                    .Skip((page - 1) * pageSize)
                    .Limit(pageSize)
                    .ToList(CancellationToken.None);

            return this.mapper.Map<List<IndicatorViewModel>>(list);
        }
    }
}
