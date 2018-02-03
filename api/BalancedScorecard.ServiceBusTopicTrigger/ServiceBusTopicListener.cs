using BalancedScorecard.Kernel.Azure;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BalancedScorecard.ServiceBusTopicTrigger
{
    public class ServiceBusTopicListener : ICommunicationListener
    {
        private readonly SubscriptionClient _subscriptionClient;
        private readonly Func<Message, Task> _processMessage;
        private readonly Func<ExceptionReceivedEventArgs, Task> _processException;

        public ServiceBusTopicListener(
            IOptions<AzureServiceBusSettings> options,
            Func<Message, Task> processMessage,
            Func<ExceptionReceivedEventArgs, Task> processException)
        {
            if (options.Value == null) throw new ArgumentNullException("AzureServiceBusSettings are null");

            _subscriptionClient = new SubscriptionClient(
                new ServiceBusConnectionStringBuilder(options.Value.Endpoint)
                {
                    EntityPath = options.Value.TopicName,
                }, "indicators-subscription");

            _processMessage = processMessage;
            _processException = processException;
        }

        public void Abort()
        {
            Stop().GetAwaiter().GetResult();  
        }

        public Task CloseAsync(CancellationToken cancellationToken)
        {
            return Stop();
        }

        public Task<string> OpenAsync(CancellationToken cancellationToken)
        {
            _subscriptionClient.RegisterMessageHandler( 
                async (message, ct) => 
                {
                    try
                    {
                        await _processMessage(message);
                        await _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
                    }
                    catch
                    {
                        await _subscriptionClient.AbandonAsync(message.SystemProperties.LockToken);
                        throw;
                    }
                },
                new MessageHandlerOptions(_processException)
                {
                    MaxConcurrentCalls = 1,
                    AutoComplete = false
                });

            return Task.FromResult(string.Empty);
        }

        private Task Stop()
        {
            if (_subscriptionClient == null)
            {
                return Task.CompletedTask;
            }

            if (_subscriptionClient.IsClosedOrClosing)
            {
                return Task.CompletedTask;
            }

            return _subscriptionClient.CloseAsync();
        }
    }
}
