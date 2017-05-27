﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using RGM.BalancedScorecard.Api.Bus;
using RGM.BalancedScorecard.Application.Infrastructure;
using RGM.BalancedScorecard.Domain.Commands;
using RGM.BalancedScorecard.Infrastructure.MongoDb.Readers.Indicators;
using RGM.BalancedScorecard.Kernel.Domain.Commands;
using RGM.BalancedScorecard.Kernel.Domain.Events;
using RGM.BalancedScorecard.Query.Readers;

namespace RGM.BalancedScorecard.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc().AddJsonOptions(options => 
            {
                options.SerializerSettings.Converters.Add(new IndicatorValueConverter());
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddOptions();

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<ICommandBus, CommandBus>();
            services.AddSingleton<IIndicatorsReader, IndicatorsReader>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseExceptionHandler();
            app.UseMvc();
        }
    }
}
