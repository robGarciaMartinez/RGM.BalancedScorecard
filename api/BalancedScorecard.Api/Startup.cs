using BalancedScorecard.Api.IoC;
using BalancedScorecard.Infrastructure.DocumentDb;
using BalancedScorecard.Infrastructure.DocumentDb.Queries.Indicators;
using BalancedScorecard.Infrastructure.SqlServerDb.JsonConverters;
using BalancedScorecard.Kernel.Azure;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Queries;
using BalancedScorecard.Query.Filter;
using BalancedScorecard.Query.Filter.Indicators;
using BalancedScorecard.Query.Model;
using BalancedScorecard.Query.Model.Indicators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StructureMap;
using System;

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
            services.Configure<DocumentDbSettings>(options => _configuration.GetSection(nameof(DocumentDbSettings)).Bind(options));
            services.AddSingleton<ICommandDispatcher, AzureCommandDispatcher>();
            services.AddSingleton<IQueryDispatcherDependencyContainer, StructureMapMediator>();
            services.AddSingleton<IQueryDispatcher, LocalQueryDispatcher>();
        }

        public void ConfigureContainer(Registry registry)
        {
            var documentDbSettings = new DocumentDbSettings();
            _configuration.GetSection(nameof(DocumentDbSettings)).Bind(documentDbSettings);

            registry.For<IDocumentClient>().Use(
                new DocumentClient(
                    new Uri(documentDbSettings.Endpoint),
                    documentDbSettings.PrimaryKey,
                    new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() }));

            registry.For<IQuery<IndicatorViewModel, GetIndicatorFilter>>().Use<GetIndicatorQuery>();
            registry.For<ICollectionQuery<IndicatorViewModel, GetIndicatorsFilter>>().Use<GetIndicatorsQuery>();
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
