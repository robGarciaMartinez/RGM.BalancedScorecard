using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RGM.BalancedScorecard.Application.Infrastructure;
using RGM.BalancedScorecard.Domain.Services.Abstractions;
using RGM.BalancedScorecard.EF.Implementations;
using RGM.BalancedScorecard.Kernel.Domain.Commands;
using RGM.BalancedScorecard.Kernel.Domain.Validation;
using StructureMap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.MessageProcessor
{
    public class Program
    {
        private static IQueueClient _queueClient;
        private static IContainer _container;

        public static void Main(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddSingleton(configuration);
            
            _container = new Container();
            _container.Configure(config =>
            {
                config.Scan(scanner =>
                {
                    scanner.TheCallingAssembly();
                    scanner.Assembly("RGM.BalancedScorecard.Application");
                    scanner.Assembly("RGM.BalancedScorecard.Domain");
                    scanner.Assembly("RGM.BalancedScorecard.Infrastructure.WriteDb");
                    scanner.Assembly("RGM.BalancedScorecard.Kernel");
                    scanner.WithDefaultConventions();
                    scanner.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
                });

                config.For<IConfiguration>().Use(configuration);
                config.For(typeof(IValidator<>)).Use(typeof(BaseValidator<>));
                config.For(typeof(IAggregateRootRepository<>)).Use(typeof(AggregateRootRepository<>));
                config.For<IQueueClient>().Use(
                    new QueueClient(configuration.GetSection("ServiceBus:ConnectionString").Value, configuration.GetSection("ServiceBus:Queue").Value, ReceiveMode.PeekLock));
            });

            _container.Populate(services);
            
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            _queueClient = _container.GetInstance<IQueueClient>();
            ReceiveMessages();

            Console.ReadKey();

            // Close the client after the ReceiveMessages method has exited.
            await _queueClient.CloseAsync();
        }

        // Receives messages from the queue in a loop
        private static void ReceiveMessages()
        {           
            // Register a OnMessage callback
            _queueClient.RegisterMessageHandler(
                async (message, token) =>
                {
                    try
                    {
                        // Process the message
                        var stringBody = message.GetBody<string>();
                        Console.WriteLine($"Received message: SequenceNumber:{message.SequenceNumber} Body:{stringBody}");

                        var messageBodyType = Type.GetType(message.ContentType);
                        var messageBody = JsonConvert.DeserializeObject(stringBody, messageBodyType, 
                            new JsonSerializerSettings
                            {
                                Converters = new List<JsonConverter> { new IndicatorValueConverter() }
                            });

                        var commandHandlerType = typeof(ICommandHandler<>).MakeGenericType(messageBodyType);
                        var commandHandler = _container.GetInstance(commandHandlerType);

                        var commandHandlerExecute = commandHandlerType.GetMethod("ExecuteAsync");
                        await ((Task)commandHandlerExecute.Invoke(commandHandler, new[] { messageBody }));

                        // Complete the message so that it is not received again.
                        // This can be done only if the queueClient is opened in ReceiveMode.PeekLock mode.
                        await _queueClient.CompleteAsync(message.LockToken);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine($"{DateTime.Now} > Exception: {exception.ToString()}");
                    }
                },
                new RegisterHandlerOptions() { MaxConcurrentCalls = 1, AutoComplete = false });
        }
    }
}