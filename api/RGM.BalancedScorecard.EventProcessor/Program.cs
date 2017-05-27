using Microsoft.Azure.ServiceBus;
//using Microsoft.ServiceBus.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RGM.BalancedScorecard.Api.Bus;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.EventProcessor
{
    class Program
    {
        static ISubscriptionClient _subscriptionClient;
        static IConfiguration _configuration;

        static void Main(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddSingleton(_configuration);

            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            _subscriptionClient = new SubscriptionClient(
                        _configuration.GetSection($"{nameof(ServiceBusSettings)}:{nameof(ServiceBusSettings.ConnectionString)}").Value,
                        _configuration.GetSection($"{nameof(ServiceBusSettings)}:{nameof(ServiceBusSettings.TopicName)}").Value,
                        "Subscription1",
                        ReceiveMode.PeekLock);

            ReceiveEvents(_subscriptionClient, ConsoleColor.Blue);

            Console.ReadKey();

            // Close the client after the ReceiveMessages method has exited.
            await _subscriptionClient.CloseAsync();
        }

        static void ReceiveEvents(ISubscriptionClient receiver, ConsoleColor color)
        {
            // register the OnMessageAsync callback
            receiver.RegisterMessageHandler(
                async (message, token) =>
                {
                    try
                    {
                        // Process the message
                        var stringBody = Encoding.UTF8.GetString(message.Body);

                        Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{stringBody}");
                        await receiver.CompleteAsync(message.SystemProperties.LockToken);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine($"{DateTime.Now} > Exception: {exception.ToString()}");
                    }
                },
                new MessageHandlerOptions { AutoComplete = false, MaxConcurrentCalls = 1 });
        }
    }
}