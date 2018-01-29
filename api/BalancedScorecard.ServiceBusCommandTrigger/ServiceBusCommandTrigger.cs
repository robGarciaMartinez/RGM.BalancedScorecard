using BalancedScorecard.Infrastructure.SqlServerDb.JsonConverters;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.ServiceBusCommandTrigger.IoC;
using Microsoft.Azure.ServiceBus;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Newtonsoft.Json;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Fabric;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BalancedScorecard.ServiceBusCommandTrigger
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class ServiceBusCommandTrigger : StatelessService
    {
        private readonly IContainer _container;

        public ServiceBusCommandTrigger(StatelessServiceContext context)
            : base(context)
        {
            _container = new Container();
            _container.Configure(conf => conf.AddRegistry<CommandHandlerStructureMapRegistry>());
        }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            yield return new ServiceInstanceListener(context => 
                new ServiceBusQueueListener(
                "Endpoint=sb://balancedscorecard.servicebus.windows.net/;SharedAccessKeyName=balancedscorecard-user;SharedAccessKey=UBQ5rVQnyevqYSzsWYl/TLYyeE4mG6r7Regsuwr4oBw=",
                "indicators-queue",
                ProcessMessage,
                ProcessException));
        }

        private Task ProcessMessage(Message message)
        {
            if (message == null) throw new ArgumentNullException("Message is null");

            var commandType = Type.GetType(message.ContentType);
            var command = JsonConvert.DeserializeObject(Encoding.Default.GetString(message.Body), commandType, new IndicatorMeasureConverter());
            var commandHandlerType = typeof(ICommandHandler<>).MakeGenericType(commandType);
            var commandHandler = _container.GetInstance(commandHandlerType);

            if (commandHandler == null) throw new InvalidOperationException($"Missing DI configuration for {commandType.Name} handler");

            return (Task)commandHandlerType.InvokeMember("Execute", BindingFlags.InvokeMethod, null, commandHandler, new[] { command });
        }

        private Task ProcessException(ExceptionReceivedEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());

            return Task.CompletedTask;
        }
    }
}
