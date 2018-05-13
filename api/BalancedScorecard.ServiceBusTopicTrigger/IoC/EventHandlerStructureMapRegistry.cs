using BalancedScorecard.Application.DomainEventHandlers.Indicators;
using BalancedScorecard.Infrastructure.DocumentDb;
using BalancedScorecard.Kernel.Azure;
using BalancedScorecard.Kernel.Events;
using BalancedScorecard.Query.Model;
using BalancedScorecard.Query.Model.Indicators;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StructureMap;
using System;

namespace BalancedScorecard.ServiceBusQueueTrigger.IoC
{
    public class EventHandlerStructureMapRegistry : Registry
    {
        public EventHandlerStructureMapRegistry(IConfiguration configuration)
        {
            var serviceBusSettings = new AzureServiceBusSettings();
            configuration.GetSection(nameof(AzureServiceBusSettings)).Bind(serviceBusSettings);

            var documentDbSettings = new DocumentDbSettings();
            configuration.GetSection(nameof(DocumentDbSettings)).Bind(documentDbSettings);

            Scan(scanner =>
            {
                scanner.WithDefaultConventions();
                scanner.Assembly(typeof(CreateIndicatorViewModelHandler).Assembly);
                scanner.Assembly(typeof(IndicatorViewModel).Assembly);
                scanner.Assembly(typeof(DocumentDbSettings).Assembly);
                scanner.ConnectImplementationsToTypesClosing(typeof(IDomainEventHandler<>));
            });

            For<IConfiguration>().Use(configuration);
            For<IOptions<AzureServiceBusSettings>>().Use(Options.Create(serviceBusSettings));
            For<IOptions<DocumentDbSettings>>().Use(Options.Create(documentDbSettings));
            For<IDocumentClient>().Use(
                new DocumentClient(
                    new Uri(documentDbSettings.Endpoint),
                    documentDbSettings.PrimaryKey,
                    new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
        }
    }
}
