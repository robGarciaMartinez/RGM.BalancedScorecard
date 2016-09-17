namespace RGM.BalancedScorecard.IoC
{
    using Application.CommandHandlers.Indicators;
    using Domain.Commands;
    using Domain.Commands.Indicators;

    using StructureMap;

    using Domain.Repositories;
    using Domain.Services.Implementation;
    using Domain.Services.Interfaces;
    using Domain.Specifications.Indicators;
    using Infrastructure.Automapper;
    using Infrastructure.MongoDb.Context;
    using Infrastructure.MongoDb.Readers.Indicators;
    using Infrastructure.MongoDb.Repositories.Indicators;
    using Query.Readers;
    using SharedKernel.DependencyContainer;
    using SharedKernel.Domain.Commands;
    using SharedKernel.Domain.Validation;

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

            this.For<ICommandHandler<CreateIndicatorMeasureCommand>>().Use<CreateIndicatorMeasureCommandHandler>();

            // Indicators validation
            this.For<ISpecification<CreateIndicatorCommand>>().Use<IndicatorCodeMustBeUniqueSpecification>();
            this.For<IValidator<CreateIndicatorCommand>>().Use<CommandValidator<CreateIndicatorCommand>>();
            this.For<ISpecification<UpdateIndicatorCommand>>().Use<IndicatorCodeMustBeUniqueSpecification>();
            this.For<IValidator<UpdateIndicatorCommand>>().Use<CommandValidator<UpdateIndicatorCommand>>();

            this.For<IIndicatorStateCalculator>().Use<IndicatorStateCalculator>();
            this.For<IIndicatorsRepository>().Use<IndicatorsRepository>();
            this.For<IIndicatorsReader>().Use<IndicatorsReader>();

            // Mongo
            this.For<IDbContext>().Use<DbContext>();

            //this.For<Infrastructure.SqlServer.Context.IDbContext>().Use<BalancedScorecardContext>();
            //this.For<IDatabaseInitializer<BalancedScorecardContext>>().Use<DropCreateDatabaseIfModelChanges<BalancedScorecardContext>>();
        }
    }
}
