namespace RGM.BalancedScorecard.Infrastructure.SqlServer.Readers.Indicators
{
    using System.Collections.Generic;

    using Microsoft.Extensions.Configuration;
    using SqlServer.Context;
    using Query.Model.Indicators;
    using Query.Readers;
    using Automapper;
    using Domain.Model.Indicators;
    using System.Linq;

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
            var indicator = this.context.Set<Indicator>().FirstOrDefault(i => i.Code == code);
            return this.mapper.Map<IndicatorViewModel>(indicator);
        }

        public List<IndicatorViewModel> GetIndicators(int page)
        {
            var pageSize = this.configuration.GetValue<int>("GeneralSettings:PageSize");
            var list = this.context.Set<Indicator>().ToList();
            return this.mapper.Map<List<IndicatorViewModel>>(list);
        }
    }
}
