namespace RGM.BalancedScorecard.IoC
{
    using System;

    using Microsoft.Extensions.DependencyInjection;

    using StructureMap;

    public static class ContainerSetup
    {
        public static IServiceProvider GetServiceProvider(IServiceCollection services)
        {
            var container = new Container(c => c.AddRegistry<DefaultRegistry>());
            container.Configure(
                config =>
                    {
                        config.Populate(services);
                    });
            return container.GetInstance<IServiceProvider>(); ;
        }
    }
}
