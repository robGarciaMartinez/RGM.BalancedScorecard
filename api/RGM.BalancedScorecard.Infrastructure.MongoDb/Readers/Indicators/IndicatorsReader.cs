using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RGM.BalancedScorecard.Query.Readers;
using RGM.BalancedScorecard.Infrastructure.MongoDb.Context;
using RGM.BalancedScorecard.Query.Model.Indicators;
using RGM.BalancedScorecard.Domain.Model.Indicators;

namespace RGM.BalancedScorecard.Infrastructure.MongoDb.Readers.Indicators
{
    public class IndicatorsReader : IIndicatorsReader
    {
        private readonly IDbContext context;

        private readonly IConfiguration configuration;

        public IndicatorsReader(IDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public IndicatorViewModel GetByCode(string code)
        {
            var indicator =
                this.context.Collection<Indicator>()
                    .FindSync(Builders<Indicator>.Filter.Where(i => i.Code == code))
                    .FirstOrDefault();

            return null;
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

            return null;
        }
    }
}
