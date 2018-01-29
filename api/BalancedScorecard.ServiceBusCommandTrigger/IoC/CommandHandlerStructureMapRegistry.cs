using BalancedScorecard.Application.CommandHandlers.Indicators;
using BalancedScorecard.Domain.Model.Indicators;
using BalancedScorecard.Infrastructure.SqlServerDb.Abstractions;
using BalancedScorecard.Infrastructure.SqlServerDb.Implementations;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Kernel.Events;
using BalancedScorecard.Kernel.Validation;
using StructureMap;

namespace BalancedScorecard.ServiceBusCommandTrigger.IoC
{
    public class CommandHandlerStructureMapRegistry : Registry
    {
        public CommandHandlerStructureMapRegistry()
        {
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

            For<IValidationDependencyContainer>().Use<StructureMapMediator>();
            For<IDomainEventDispatcher>().Use<AzureEventDispatcher>();
        }
    }
}
