namespace RGM.BalancedScorecard.Infrastructure.Mongo.Readers.Indicators
{
    using MongoDB.Driver;

    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Infrastructure.Automapper;
    using RGM.BalancedScorecard.Query.Model.Indicators;
    using RGM.BalancedScorecard.Query.Readers;

    public class IndicatorsReader : IIndicatorsReader
    {
        private readonly IMongoCollection<Indicator> collection;

        private readonly IMapper mapper;

        public IndicatorsReader(IMongoDatabase database, IMapper mapper)
        {
            this.collection = database.GetCollection<Indicator>("Indicators");
            this.mapper = mapper;
        }

        public IndicatorViewModel GetByCode(string code)
        {
            var indicator = this.collection.Find(i => i.Code == code).FirstOrDefault();
            return this.mapper.Map<IndicatorViewModel>(indicator);
        }
    }
}
