using BalancedScorecard.Api.IoC;
using BalancedScorecard.Api.JsonConverters;
using BalancedScorecard.Application.CommandHandlers;
using BalancedScorecard.Domain.Model.Indicators;
using BalancedScorecard.Infrastructure.Persistence.Abstractions;
using BalancedScorecard.Infrastructure.Persistence.Implementations;
using BalancedScorecard.Kernel;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Kernel.Queries;
using BalancedScorecard.Kernel.Validation;
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
            services.AddMvc().AddJsonOptions(
                options => options.SerializerSettings.Converters.Add(new IndicatorMeasureConverter()));
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
            services.AddScoped<IValidationDependencyContainer, StructureMapMediator>();
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
                scanner.AddAllTypesOf(typeof(IQuery<,>));
                scanner.AddAllTypesOf(typeof(IMapper<>));
                scanner.AddAllTypesOf(typeof(IRepository<>));
                scanner.AddAllTypesOf(typeof(IValidator<>));
                scanner.AddAllTypesOf(typeof(ISpecification<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IQuery<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IMapper<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IRepository<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IValidator<>));
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
