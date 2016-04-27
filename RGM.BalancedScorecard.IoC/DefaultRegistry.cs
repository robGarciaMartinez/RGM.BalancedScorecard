namespace RGM.BalancedScorecard.IoC
{
    using RGM.BalancedScorecard.Domain.Commands;
    using RGM.BalancedScorecard.Domain.Commands.Indicators;
    using RGM.BalancedScorecard.Domain.Dependencies;

    using StructureMap;

    using RGM.BalancedScorecard.Domain.Repositories;
    using RGM.BalancedScorecard.Infrastructure.Mongo.Indicators;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            this.For<ICommandBus>().Use<CommandBus>();
            this.For<ICommandHandler<CreateIndicatorCommand>>().Use<CreateIndicatorCommandHandler>();
            this.For<IDomainDependencyService>().Use<DependencyService>();
            this.For<IIndicatorsRepository>().Use<IndicatorsRepository>();
        }
    }
}
