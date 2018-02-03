using BalancedScorecard.Infrastructure.DocumentDb;
using BalancedScorecard.Infrastructure.DocumentDb.Readers;
using BalancedScorecard.Infrastructure.SqlServerDb.JsonConverters;
using BalancedScorecard.Kernel.Azure;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Query.Readers.Indicators;
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
            services.Configure<AzureDocumentDbSettings>(options => _configuration.GetSection(nameof(AzureDocumentDbSettings)).Bind(options));
            services.AddSingleton<ICommandDispatcher, AzureCommandDispatcher>();
            services.AddScoped<IIndicatorCollectionReader, IndicatorCollectionReader>();
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
