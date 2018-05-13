using BalancedScorecard.Domain.Commands.Indicators;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Queries;
using BalancedScorecard.Query.Filter.Indicators;
using BalancedScorecard.Query.Model.Indicators;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("{code}", Name = "GetIndicator")]
        public Task<IndicatorViewModel> GetIndicator(string code)
        {
            return 
                _queryDispatcher.Get<IndicatorViewModel, GetIndicatorViewModelFilter>(
                    new GetIndicatorViewModelFilter(code));
        }

        [HttpPost]
        public async Task<IActionResult> CreateIndicator(
            [FromBody] CreateIndicatorCommand command)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState);

            command.IndicatorId = Guid.NewGuid();
            await _commandDispatcher.Send(command);
            return new CreatedAtRouteResult("GetIndicator", new { indicatorId = command.IndicatorId }, null);
        }

        [HttpPut("{indicatorId}")]
        public async Task<IActionResult> UpdateIndicator(
            [FromRoute] Guid indicatorId,
            [FromBody] UpdateIndicatorCommand command)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState);

            command.IndicatorId = indicatorId;
            await _commandDispatcher.Send(command);
            return new OkResult();
        }

        [HttpPost("{indicatorId}/measures")]
        public async Task<IActionResult> CreateIndicatorMeasure(
            [FromRoute]Guid indicatorId, 
            [FromBody] CreateIndicatorMeasureCommand command)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState);

            command.IndicatorId = indicatorId;
            command.IndicatorMeasureId = Guid.NewGuid();
            await _commandDispatcher.Send(command);
            return new OkResult();
        }

        [HttpPost("{indicatorId}/measures/{indicatorMeasureId}")]
        public async Task<IActionResult> CreateIndicatorMeasure(
            [FromRoute]Guid indicatorId, 
            [FromRoute]Guid indicatorMeasureId, 
            [FromBody] CreateIndicatorMeasureCommand command)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState);

            command.IndicatorId = indicatorId;
            command.IndicatorMeasureId = indicatorMeasureId;
            await _commandDispatcher.Send(command);
            return new OkResult();
        }
    }
}