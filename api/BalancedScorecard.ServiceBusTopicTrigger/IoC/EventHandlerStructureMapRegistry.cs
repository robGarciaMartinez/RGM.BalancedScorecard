using BalancedScorecard.Application.DomainEventHandlers.Indicators;
using BalancedScorecard.Infrastructure.DocumentDb.Readers;
using BalancedScorecard.Kernel.Events;
using BalancedScorecard.Query.Model;
using StructureMap;

namespace BalancedScorecard.ServiceBusQueueTrigger.IoC
{
    public class EventHandlerStructureMapRegistry : Registry
    {
        public EventHandlerStructureMapRegistry()
        {
            Scan(scanner =>
            {
                scanner.WithDefaultConventions();
                scanner.Assembly(typeof(CreateIndicatorViewModelHandler).Assembly);
                scanner.Assembly(typeof(IndicatorViewModel).Assembly);
                scanner.Assembly(typeof(BaseCollectionReader).Assembly);
                scanner.ConnectImplementationsToTypesClosing(typeof(IDomainEventHandler<>));
            });
        }
    }
}
