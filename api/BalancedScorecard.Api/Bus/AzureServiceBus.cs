using BalancedScorecard.Kernel.Commands;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedScorecard.Api.Bus
{
    public class AzureServiceBus : ICommandBus
    {
        private readonly IQueueClient _queueClient;

        public AzureServiceBus(IOptions<AzureServiceBusSettings> options)
        {
            if (options.Value == null) throw new ArgumentNullException("AzureServiceBusSettings are null");

            _queueClient = new QueueClient(options.Value.Endpoint, options.Value.QueueName);
        }

        public Task Send(ICommand command)
        {
            return _queueClient.SendAsync(CreateMessage(command));
        }

        public Task Send(IEnumerable<ICommand> commands)
        {
            return _queueClient.SendAsync(commands.Select(c => CreateMessage(c)).ToList());
        }

        private Message CreateMessage(ICommand command)
        {
            var message = new Message(
                Encoding.UTF8.GetBytes(
                    JsonConvert.SerializeObject(
                        command,
                        new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() })));

            message.ContentType = command.GetType().AssemblyQualifiedName;

            return message;
        }
    }
}
