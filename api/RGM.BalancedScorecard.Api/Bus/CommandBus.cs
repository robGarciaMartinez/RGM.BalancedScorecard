using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RGM.BalancedScorecard.Api.Bus;
using RGM.BalancedScorecard.Kernel.Domain.Commands;
using System;
using System.Text;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.Domain.Commands
{
    public class CommandBus : ICommandBus
    {
        private readonly IQueueClient _queueClient;

        public CommandBus(IConfiguration configuration)
        {
            _queueClient = 
                new QueueClient(
                    configuration.GetSection($"{nameof(ServiceBusSettings)}:{nameof(ServiceBusSettings.ConnectionString)}").Value,
                    configuration.GetSection($"{nameof(ServiceBusSettings)}:{nameof(ServiceBusSettings.QueueName)}").Value, ReceiveMode.PeekLock);
        }

        public Task SubmitAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            var jsonCommand = JsonConvert.SerializeObject(command,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            var type = Type.GetType(typeof(TCommand).AssemblyQualifiedName);

            return _queueClient.SendAsync(
                new Message(Encoding.UTF8.GetBytes(jsonCommand)) { ContentType = type.AssemblyQualifiedName });
        }
    }
}
