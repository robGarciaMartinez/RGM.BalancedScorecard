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
    using RGM.BalancedScorecard.Infrastructure.Mongo.Context;
    using RGM.BalancedScorecard.Infrastructure.Mongo.Readers.Indicators;
    using RGM.BalancedScorecard.Infrastructure.Mongo.Repositories.Indicators;
    using RGM.BalancedScorecard.Query.Readers;
    using RGM.BalancedScorecard.SharedKernel.DependencyContainer;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;
    using RGM.BalancedScorecard.SharedKernel.Domain.Validation;

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

            this.For<IIndicatorStateCalculator>().Use<IndicatorStateCalculator>();
            this.For<IIndicatorsRepository>().Use<IndicatorsRepository>();
            this.For<IIndicatorsReader>().Use<IndicatorsReader>();

            // Mongo
            this.For<IDbContext>().Use<DbContext>();
        }
    }
}
