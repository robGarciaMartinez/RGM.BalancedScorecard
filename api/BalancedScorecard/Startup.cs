using BalancedScorecard.Application.CommandHandlers;
using BalancedScorecard.Domain.Commands.Indicators;
using BalancedScorecard.Domain.Model.Indicators;
using BalancedScorecard.Infrastructure.Persistence.Abstractions;
using BalancedScorecard.Infrastructure.Persistence.Implementations;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BalancedScorecard.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<ICommandHandler<CreateIndicatorCommand>, CreateIndicatorCommandHandler>();
            services.AddTransient<IMapper<Indicator>, AggregateRootMapper<Indicator>>();
            services.AddTransient<IRepository<Indicator>, SqlServerRepository<Indicator>>();
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
