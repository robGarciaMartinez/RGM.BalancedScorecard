using BalancedScorecard.Application.CommandHandlers.Indicators;
using BalancedScorecard.Domain.Model.Indicators;
using BalancedScorecard.Infrastructure.SqlServerDb.Abstractions;
using BalancedScorecard.Infrastructure.SqlServerDb.Implementations;
using BalancedScorecard.Kernel.Azure;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Kernel.Events;
using BalancedScorecard.Kernel.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StructureMap;

namespace BalancedScorecard.ServiceBusQueueTrigger.IoC
{
    public class CommandHandlerStructureMapRegistry : Registry
    {
        public CommandHandlerStructureMapRegistry(IConfiguration configuration)
        {
            var settings = new AzureServiceBusSettings();
            configuration.GetSection(nameof(AzureServiceBusSettings)).Bind(settings);

            Scan(scanner =>
            {
                scanner.WithDefaultConventions();
                scanner.Assembly(typeof(CreateIndicatorCommandHandler).Assembly);
                scanner.Assembly(typeof(Indicator).Assembly);
                scanner.Assembly(typeof(SqlServerRepository<Indicator>).Assembly);
                scanner.Assembly(typeof(BaseEntity).Assembly);
                scanner.AddAllTypesOf(typeof(IValidator<>));
                scanner.AddAllTypesOf(typeof(IRepository<>));
                scanner.AddAllTypesOf(typeof(IMapper<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(ISpecification<>));
            });

            For<IConfiguration>().Use(configuration);
            For<IValidationDependencyContainer>().Use<StructureMapMediator>();
            For<IOptions<AzureServiceBusSettings>>().Use(Options.Create(settings));
            For<IDomainEventDispatcher>().Use<AzureEventDispatcher>();
        }
    }
}
