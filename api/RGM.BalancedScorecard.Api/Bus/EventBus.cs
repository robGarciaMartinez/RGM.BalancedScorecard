using System;
using System.Threading.Tasks;
using RGM.BalancedScorecard.Kernel.Domain.Events;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using System.Text;
using Newtonsoft.Json;

namespace RGM.BalancedScorecard.Api.Bus
{
    public class EventBus : IEventBus
    {
        private readonly ITopicClient _topicClient;

        public EventBus(IConfiguration configuration)
        {
            _topicClient =
                new TopicClient(
                    configuration.GetSection($"{nameof(ServiceBusSettings)}:{nameof(ServiceBusSettings.ConnectionString)}").Value,
                    configuration.GetSection($"{nameof(ServiceBusSettings)}:{nameof(ServiceBusSettings.TopicName)}").Value);
        }

        public Task SubmitAsync<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent
        {
            var jsonCommand = JsonConvert.SerializeObject(domainEvent);
            var type = Type.GetType(typeof(TEvent).AssemblyQualifiedName);

            return _topicClient.SendAsync(
                new Message(Encoding.UTF8.GetBytes(jsonCommand)) { ContentType = type.AssemblyQualifiedName });
        }
    }
}
