using BalancedScorecard.Application.DomainEventHandlers.Indicators;
using BalancedScorecard.Infrastructure.DocumentDb;
using BalancedScorecard.Infrastructure.DocumentDb.Readers;
using BalancedScorecard.Kernel.Azure;
using BalancedScorecard.Kernel.Events;
using BalancedScorecard.Query.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StructureMap;

namespace BalancedScorecard.ServiceBusQueueTrigger.IoC
{
    public class EventHandlerStructureMapRegistry : Registry
    {
        public EventHandlerStructureMapRegistry(IConfiguration configuration)
        {
            var serviceBusSettings = new AzureServiceBusSettings();
            configuration.GetSection(nameof(AzureServiceBusSettings)).Bind(serviceBusSettings);

            var documentDbSettings = new AzureDocumentDbSettings();
            configuration.GetSection(nameof(AzureDocumentDbSettings)).Bind(documentDbSettings);

            Scan(scanner =>
            {
                scanner.WithDefaultConventions();
                scanner.Assembly(typeof(CreateIndicatorViewModelHandler).Assembly);
                scanner.Assembly(typeof(IndicatorViewModel).Assembly);
                scanner.Assembly(typeof(BaseCollectionReader).Assembly);
                scanner.ConnectImplementationsToTypesClosing(typeof(IDomainEventHandler<>));
            });

            For<IConfiguration>().Use(configuration);
            For<IOptions<AzureServiceBusSettings>>().Use(Options.Create(serviceBusSettings));
            For<IOptions<AzureDocumentDbSettings>>().Use(Options.Create(documentDbSettings));
        }
    }
}
