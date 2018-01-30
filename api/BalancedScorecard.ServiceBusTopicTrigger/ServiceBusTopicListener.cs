using Microsoft.Azure.ServiceBus;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BalancedScorecard.ServiceBusTopicTrigger
{
    public class ServiceBusTopicListener : ICommunicationListener
    {
        private readonly string _connectionString;
        private readonly SubscriptionClient _subscriptionClient;
        private readonly Func<Message, Task> _processMessage;
        private readonly Func<ExceptionReceivedEventArgs, Task> _processException;

        public ServiceBusTopicListener(
            string connectionString, 
            string topicName,
            Func<Message, Task> processMessage,
            Func<ExceptionReceivedEventArgs, Task> processException)
        {
            _connectionString = connectionString;
            _subscriptionClient = new SubscriptionClient(
                new ServiceBusConnectionStringBuilder(_connectionString)
                {
                    EntityPath = topicName,
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

            return Task.FromResult(_connectionString);
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
