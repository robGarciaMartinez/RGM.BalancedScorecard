using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Events
{
    public class AzureEventDispatcher : IDomainEventDispatcher
    {
        private readonly ITopicClient _topicClient;

        public AzureEventDispatcher()
        {
            _topicClient = new TopicClient(
                "Endpoint=sb://balancedscorecard.servicebus.windows.net/;SharedAccessKeyName=balancedscorecard-user;SharedAccessKey=UBQ5rVQnyevqYSzsWYl/TLYyeE4mG6r7Regsuwr4oBw=", 
                "indicators-topic");
        }

        public Task DispatchDomainEvents<TEvent>(IEnumerable<TEvent> domainEvents) where TEvent : class, IDomainEvent
        {
            return _topicClient.SendAsync(domainEvents.Select(d => CreateMessage(d)).ToList());
        }

        private Message CreateMessage(IDomainEvent domainEvent)
        {
            var message = new Message(
                Encoding.UTF8.GetBytes(
                    JsonConvert.SerializeObject(
                        domainEvent,
                        new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() })));

            message.ContentType = domainEvent.GetType().AssemblyQualifiedName;

            return message;
        }
    }
}
