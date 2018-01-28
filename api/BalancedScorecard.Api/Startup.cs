using BalancedScorecard.Api.Bus;
using BalancedScorecard.Infrastructure.SqlServerDb.JsonConverters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace BalancedScorecard.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddJsonOptions(
                options => {
                    options.SerializerSettings.Converters.Add(new IndicatorMeasureConverter());
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            services.AddCors(
                options => options.AddPolicy("Local", 
                builder => 
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                }));


            services.AddOptions();
            services.Configure<AzureServiceBusSettings>(options => _configuration.GetSection(nameof(AzureServiceBusSettings)).Bind(options));

            services.AddSingleton<ICommandBus, AzureServiceBus>();
        }

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
