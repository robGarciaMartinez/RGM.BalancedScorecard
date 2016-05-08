namespace RGM.BalancedScorecard.IoC
{
    using MongoDB.Driver;

    using RGM.BalancedScorecard.Domain.Commands;
    using RGM.BalancedScorecard.Domain.Commands.Indicators;
    using RGM.BalancedScorecard.Domain.Dependencies;

    using StructureMap;

    using RGM.BalancedScorecard.Domain.Repositories;
    using RGM.BalancedScorecard.Infrastructure.Automapper;
    using RGM.BalancedScorecard.Infrastructure.Mongo.Read.Indicators;
    using RGM.BalancedScorecard.Infrastructure.Mongo.Write.Indicators;
    using RGM.BalancedScorecard.Query.Readers;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            // General
            this.For<ICommandBus>().Use<CommandBus>();
            this.For<IMapper>().Use<CustomMapper>();
            this.For<AutoMapper.IMapper>().Use(Mappings.Configuration.CreateMapper());
            this.For<IDomainDependencyService>().Use<DependencyService>();

            // Indicators
            this.For<ICommandHandler<CreateIndicatorCommand>>().Use<CreateIndicatorCommandHandler>();
            this.For<ICommandHandler<UpdateIndicatorCommand>>().Use<UpdateIndicatorCommandHandler>();
            this.For<IIndicatorsRepository>().Use<IndicatorsRepository>();
            this.For<IIndicatorsReader>().Use<IndicatorsReader>();

            // Mongo
            this.For<IMongoDatabase>().Use(new MongoClient("mongodb://localhost:27017").GetDatabase("BalancedScorecard"));
        }
    }
}
