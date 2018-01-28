using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Kernel.Events;
using BalancedScorecard.Kernel.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace BalancedScorecard.Kernel
{
    /// <summary>
    /// Class to register with the IoC the RHS Shared Kernel services
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds to the IoC the class that executes commands locally by getting particular command handler from the IoC rather than using a real Servicec Bus.
        /// Requires the ICommandDispatcherDependencyContainer to be implemented locally
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddLocalCommandDispatcher<TDependencyContainerImplementation>(this IServiceCollection services)
            where TDependencyContainerImplementation : class, ICommandDispatcherDependencyContainer
        {
            services.AddScoped<ICommandDispatcher, LocalCommandDispatcher>();
            services.AddScoped<ICommandDispatcherDependencyContainer, TDependencyContainerImplementation>();
            return services;
        }

        /// <summary>
        /// Adds to the IoC the class that dispatches events locally by getting the event handlers from the IoC.
        /// Requires the IDomainEventDispatcherDependencyContainer to be implemented locally
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddLocalDomainEventDispatcher<TDependencyContainerImplementation>(this IServiceCollection services) 
            where TDependencyContainerImplementation : class, IDomainEventDispatcherDependencyContainer
        {
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
            services.AddScoped<IDomainEventDispatcherDependencyContainer, TDependencyContainerImplementation>();
            return services;
        }

        /// <summary>
        /// Adds to the IoC the class that dispatches integration events locally by getting the event handlers from the IoC.
        /// Requires the IIntegrationEventDispatcherDependencyContainer to be implemented locally
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddLocalIntegrationEventDispatcher<TDependencyContainerImplementation>(this IServiceCollection services)
            where TDependencyContainerImplementation : class, IIntegrationEventDispatcherDependencyContainer
        {
            services.AddScoped<IIntegrationEventDispatcher, LocalIntegrationEventDispatcher>();
            services.AddScoped<IIntegrationEventDispatcherDependencyContainer, TDependencyContainerImplementation>();
            return services;
        }

        /// <summary>
        /// Adds to the IoC the class that dispatches queries by getting the query handlers from the IoC.
        /// Requires the IQueryDispatcherDependencyContainer to be implemented locally
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddLocalQueryDispatcher<TDependencyContainerImplementation>(this IServiceCollection services)
            where TDependencyContainerImplementation : class, IQueryDispatcherDependencyContainer
        {
            services.AddScoped<IQueryDispatcher, LocalQueryDispatcher>();
            services.AddScoped<IQueryDispatcherDependencyContainer, TDependencyContainerImplementation>();
            return services;
        }
    }
}
