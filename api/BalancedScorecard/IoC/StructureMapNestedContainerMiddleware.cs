using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;
using System.Threading.Tasks;

namespace BalancedScorecard.Api.IoC
{
    public class StructureMapNestedContainerMiddleware
    {
        private readonly RequestDelegate _next;

        public StructureMapNestedContainerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var serviceProvider = context.RequestServices;
            var container = serviceProvider.GetRequiredService(typeof(IContainer)) as IContainer;
            if (container != null)
            {
                using (var requestContainer = container.GetNestedContainer())
                {
                    context.RequestServices = requestContainer.GetInstance<IServiceProvider>();
                    await _next.Invoke(context);
                }
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
