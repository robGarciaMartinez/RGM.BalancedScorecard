using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace BalancedScorecard.Api.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            if (context == null) throw new ArgumentNullException("Context can't be null");
            if (context.Exception == null) throw new ArgumentNullException("Exception can't be null");

            context.Result = new OkObjectResult(context.Exception.ToString());

            return Task.CompletedTask;
        }
    }
}
