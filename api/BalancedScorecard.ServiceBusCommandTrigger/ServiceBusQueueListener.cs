using BalancedScorecard.Kernel.Azure;
using Microsoft.Azure.ServiceBus;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BalancedScorecard.ServiceBusQueueTrigger
{
    public class ServiceBusQueueListener : ICommunicationListener
    {
        private readonly QueueClient _queueClient;
        private readonly Func<Message, Task> _processMessage;
        private readonly Func<ExceptionReceivedEventArgs, Task> _processException;

        public ServiceBusQueueListener(
            AzureServiceBusSettings options,
            Func<Message, Task> processMessage,
            Func<ExceptionReceivedEventArgs, Task> processException)
        {
            _queueClient = new QueueClient(
                new ServiceBusConnectionStringBuilder(options.Endpoint)
                {
                    EntityPath = options.QueueName
                });

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
            _queueClient.RegisterMessageHandler( 
                async (message, ct) => 
                {
                    try
                    {
                        await _processMessage(message);
                        await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
                    }
                    catch
                    {
                        await _queueClient.AbandonAsync(message.SystemProperties.LockToken);
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
            if (_queueClient == null)
            {
                return Task.CompletedTask;
            }

            if (_queueClient.IsClosedOrClosing)
            {
                return Task.CompletedTask;
            }

            return _queueClient.CloseAsync();
        }
    }
}
