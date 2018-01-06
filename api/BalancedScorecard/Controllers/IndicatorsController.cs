using BalancedScorecard.Domain.Commands.Indicators;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Queries;
using BalancedScorecard.Query.Filter;
using BalancedScorecard.Query.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BalancedScorecard.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("Local")]
    public class IndicatorsController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public IndicatorsController(
            ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet(Name = "GetIndicator")]
        public Task<IndicatorViewModel> Get(string code)
        {
            return _queryDispatcher.Get<IndicatorViewModel, GetIndicatorViewModelFilter>(new GetIndicatorViewModelFilter { Code = code });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateIndicatorCommand command)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            await _commandDispatcher.Submit(command);
            return new CreatedAtRouteResult("GetIndicator", new { code = command.Code }, null);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateIndicatorCommand command)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            await _commandDispatcher.Submit(command);
            return new OkResult();
        }
    }
}