using BalancedScorecard.Api.IoC;
using BalancedScorecard.Infrastructure.DocumentDb;
using BalancedScorecard.Infrastructure.SqlServerDb.JsonConverters;
using BalancedScorecard.Kernel;
using BalancedScorecard.Kernel.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using StructureMap;

namespace BalancedScorecard.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IContainer _container;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _container = new Container();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
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

            
            services.AddLocalCommandDispatcher<StructureMapMediator>();
            services.AddLocalQueryDispatcher<StructureMapMediator>();
            services.AddLocalDomainEventDispatcher<StructureMapMediator>();
            services.AddScoped<IValidationDependencyContainer, StructureMapMediator>();
            services.Configure<DocumentDbSettings>(options => _configuration.GetSection(nameof(DocumentDbSettings)).Bind(options));

            _container.Configure(config => config.AddRegistry<StructureMapRegistry>());
            _container.Populate(services);

            services.AddSingleton(_container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<StructureMapNestedContainerMiddleware>();
            app.UseMvc();
        }
    }
}
