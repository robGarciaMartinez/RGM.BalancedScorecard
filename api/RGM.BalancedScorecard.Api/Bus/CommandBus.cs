using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using RGM.BalancedScorecard.Kernel.Domain.Commands;
using System;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.Domain.Commands
{
    public class CommandBus : ICommandBus
    {
        private readonly IQueueClient _queueClient;

        public CommandBus()
        {
            _queueClient = new QueueClient("Endpoint=sb://rhs-vm.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=KgBTWolG/AMjfA1f3Gw/8lhk7wOc4ghaIa9oYW2EYOg=", "indicators");
        }

        public Task SubmitAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            var type = Type.GetType(typeof(TCommand).AssemblyQualifiedName);
            return _queueClient.SendAsync(new Message(JsonConvert.SerializeObject(command)) { ContentType = typeof(TCommand).AssemblyQualifiedName });
        }
    }
}
