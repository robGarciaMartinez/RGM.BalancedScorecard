using BalancedScorecard.Domain.Commands.Indicators;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Query.Model;
using BalancedScorecard.Query.Readers.Indicators;
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
        private readonly ICommandDispatcher _commandBus;
        private readonly IIndicatorCollectionReader _indicatorsReader;

        public IndicatorsController(
            ICommandDispatcher commandBus,
            IIndicatorCollectionReader indicatorsReaders)
        {
            _commandBus = commandBus;
            _indicatorsReader = indicatorsReaders;
        }

        [HttpGet("{indicatorId}", Name = "GetIndicator")]
        public Task<IndicatorViewModel> GetIndicator(Guid indicatorId)
        {
            return _indicatorsReader.GetIndicatorViewModel(indicatorId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIndicator(
            [FromBody] CreateIndicatorCommand command)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState);

            command.IndicatorId = Guid.NewGuid();
            await _commandBus.Send(command);
            return new CreatedAtRouteResult("GetIndicator", new { indicatorId = command.IndicatorId }, null);
        }

        [HttpPut("{indicatorId}")]
        public async Task<IActionResult> UpdateIndicator(
            [FromRoute]Guid indicatorId, 
            [FromBody] UpdateIndicatorCommand command)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState);

            command.IndicatorId = indicatorId;
            await _commandBus.Send(command);
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
            await _commandBus.Send(command);
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
            await _commandBus.Send(command);
            return new OkResult();
        }
    }
}