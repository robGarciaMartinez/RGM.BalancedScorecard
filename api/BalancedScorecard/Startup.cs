using BalancedScorecard.Api.IoC;
using BalancedScorecard.Application.CommandHandlers;
using BalancedScorecard.Domain.Model.Indicators;
using BalancedScorecard.Infrastructure.Persistence.Abstractions;
using BalancedScorecard.Infrastructure.Persistence.Implementations;
using BalancedScorecard.Kernel;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;

namespace BalancedScorecard.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddLocalCommandDispatcher<StructureMapMediator>();
        }

        public void ConfigureContainer(Registry registry)
        {
            registry.Scan(scanner =>
            {
                scanner.Assembly(typeof(CreateIndicatorCommandHandler).Assembly);
                scanner.Assembly(typeof(Indicator).Assembly);
                scanner.Assembly(typeof(LocalCommandDispatcher).Assembly);
                scanner.Assembly(typeof(SqlServerRepository<Indicator>).Assembly);
                scanner.WithDefaultConventions();
                scanner.AddAllTypesOf(typeof(ICommandHandler<>));
                scanner.AddAllTypesOf(typeof(IMapper<>));
                scanner.AddAllTypesOf(typeof(IRepository<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IMapper<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IRepository<>));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
