using BalancedScorecard.Kernel.Events;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Azure
{
    public class AzureEventDispatcher : IDomainEventDispatcher
    {
        private readonly ITopicClient _topicClient;

        public AzureEventDispatcher(IOptions<AzureServiceBusSettings> options)
        {
            if (options.Value == null) throw new ArgumentNullException("AzureServiceBusSettings are null");

            _topicClient = new TopicClient(options.Value.Endpoint, options.Value.TopicName);
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
