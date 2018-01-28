using BalancedScorecard.Application.CommandHandlers;
using BalancedScorecard.Domain.Model.Indicators;
using BalancedScorecard.Infrastructure.DocumentDb.Readers;
using BalancedScorecard.Infrastructure.SqlServerDb.Abstractions;
using BalancedScorecard.Infrastructure.SqlServerDb.Implementations;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Kernel.Validation;
using BalancedScorecard.Query.Model;
using StructureMap;

namespace BalancedScorecard.Api.IoC
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            Scan(scanner =>
            {
                scanner.WithDefaultConventions();
                scanner.Assembly(typeof(CreateIndicatorCommandHandler).Assembly);
                scanner.Assembly(typeof(Indicator).Assembly);
                scanner.Assembly(typeof(LocalCommandDispatcher).Assembly);
                scanner.Assembly(typeof(SqlServerRepository<Indicator>).Assembly);
                scanner.Assembly(typeof(BaseCollectionReader).Assembly);
                scanner.Assembly(typeof(IndicatorViewModel).Assembly);
                scanner.AddAllTypesOf(typeof(IValidator<>));
                scanner.AddAllTypesOf(typeof(IRepository<>));
                scanner.AddAllTypesOf(typeof(IMapper<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(ISpecification<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IIntegrationDomainEventHandler<>));
            });
        }
    }
}
