using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RGM.BalancedScorecard.Kernel.Domain.Commands;
using System;
using System.Text;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.Domain.Commands
{
    public class CommandBus : ICommandBus
    {
        private readonly IQueueClient _queueClient;

        public CommandBus()
        {
            _queueClient = new QueueClient(
                "Endpoint=sb://rhs-vm.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=KgBTWolG/AMjfA1f3Gw/8lhk7wOc4ghaIa9oYW2EYOg=", 
                "indicators");
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
