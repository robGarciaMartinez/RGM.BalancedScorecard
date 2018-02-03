using BalancedScorecard.Infrastructure.SqlServerDb.JsonConverters;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Events;
using BalancedScorecard.ServiceBusQueueTrigger.IoC;
using Microsoft.Azure.ServiceBus;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Newtonsoft.Json;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BalancedScorecard.ServiceBusTopicTrigger
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class ServiceBusTopicTrigger : StatelessService
    {
        private readonly IContainer _container;

        public ServiceBusTopicTrigger(StatelessServiceContext context)
            : base(context)
        {
            _container = new Container();
            _container.Configure(conf => conf.AddRegistry<EventHandlerStructureMapRegistry>());
        }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            yield return new ServiceInstanceListener(context =>
                new ServiceBusTopicListener(
                "Endpoint=sb://balancedscorecard.servicebus.windows.net/;SharedAccessKeyName=balancedscorecard-user;SharedAccessKey=UBQ5rVQnyevqYSzsWYl/TLYyeE4mG6r7Regsuwr4oBw=",
                "indicators-topic",
                ProcessMessage,
                ProcessException));
        }

        private Task ProcessMessage(Message message)
        {
            if (message == null) throw new ArgumentNullException("Message is null");

            var domainEventType = Type.GetType(message.ContentType);
            var domainEvent = JsonConvert.DeserializeObject(Encoding.Default.GetString(message.Body), domainEventType, new IndicatorMeasureConverter());
            var domainEventHandlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEventType);
            var domainEventHandler = _container.GetInstance(domainEventHandlerType);

            if (domainEventHandler == null) throw new InvalidOperationException($"Missing DI configuration for {domainEventType.Name} handler");

            return (Task)domainEventHandlerType.InvokeMember("Handle", BindingFlags.InvokeMethod, null, domainEventHandler, new[] { domainEvent });
        }

        private Task ProcessException(ExceptionReceivedEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());

            return Task.CompletedTask;
        }
    }
}
