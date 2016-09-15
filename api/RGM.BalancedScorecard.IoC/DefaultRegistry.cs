namespace RGM.BalancedScorecard.IoC
{
    using RGM.BalancedScorecard.Application.CommandHandlers.Indicators;
    using RGM.BalancedScorecard.Domain.Commands;
    using RGM.BalancedScorecard.Domain.Commands.Indicators;

    using StructureMap;

    using RGM.BalancedScorecard.Domain.Repositories;
    using RGM.BalancedScorecard.Domain.Services.Implementation;
    using RGM.BalancedScorecard.Domain.Services.Interfaces;
    using RGM.BalancedScorecard.Domain.Specifications.Indicators;
    using RGM.BalancedScorecard.Infrastructure.Automapper;
    using RGM.BalancedScorecard.Infrastructure.MongoDb.Context;
    using RGM.BalancedScorecard.Infrastructure.MongoDb.Readers.Indicators;
    using RGM.BalancedScorecard.Infrastructure.MongoDb.Repositories.Indicators;
    using RGM.BalancedScorecard.Query.Readers;
    using RGM.BalancedScorecard.SharedKernel.DependencyContainer;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;
    using RGM.BalancedScorecard.SharedKernel.Domain.Validation;
    using Infrastructure.SqlServer.Context;
    using System.Data.Entity;

    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            // General
            this.For<ICommandBus>().Use<CommandBus>();
            this.For<IMapper>().Use<CustomMapper>();
            this.For<AutoMapper.IMapper>().Use(Mappings.Configuration.CreateMapper());
            this.For<IDependencyContainer>().Use<CustomDependencyContainer>();

            // Indicators command handlers
            this.For<ICommandHandler<CreateIndicatorCommand>>().Use<CreateIndicatorCommandHandler>();
            this.For<ICommandHandler<UpdateIndicatorCommand>>().Use<UpdateIndicatorCommandHandler>();
            this.For<ICommandHandler<DeleteIndicatorCommand>>().Use<DeleteIndicatorCommandHandler>();

            // Indicators validation
            this.For<ISpecification<CreateIndicatorCommand>>().Use<IndicatorCodeMustBeUniqueSpecification>();
            this.For<IValidator<CreateIndicatorCommand>>().Use<CommandValidator<CreateIndicatorCommand>>();
            this.For<ISpecification<UpdateIndicatorCommand>>().Use<IndicatorCodeMustBeUniqueSpecification>();
            this.For<IValidator<UpdateIndicatorCommand>>().Use<CommandValidator<UpdateIndicatorCommand>>();

            this.For<IIndicatorStateCalculator>().Use<IndicatorStateCalculator>();
            //this.For<IIndicatorsRepository>().Use<IndicatorsRepository>();
            this.For<IIndicatorsRepository>().Use<Infrastructure.SqlServer.Repositories.Indicators.IndicatorsRepository>();
            //this.For<IIndicatorsReader>().Use<IndicatorsReader>();
            this.For<IIndicatorsReader>().Use<Infrastructure.SqlServer.Readers.Indicators.IndicatorsReader>();

            // Mongo
            //this.For<IDbContext>().Use<DbContext>();
            this.For<Infrastructure.SqlServer.Context.IDbContext>().Use<BalancedScorecardContext>();
            this.For<IDatabaseInitializer<BalancedScorecardContext>>().Use<DropCreateDatabaseIfModelChanges<BalancedScorecardContext>>();
        }
    }
}
