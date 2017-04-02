using Microsoft.AspNetCore.Mvc;
using RGM.BalancedScorecard.Domain.Commands.Indicators;
using RGM.BalancedScorecard.Kernel.Domain.Commands;
using RGM.BalancedScorecard.Query.Readers;
using System;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.API.Controllers
{
    [Route("api/[controller]")]
    public class IndicatorsController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IIndicatorsReader _indicatorReader;

        public IndicatorsController(ICommandBus commandBus, IIndicatorsReader indicatorReader)
        {
            _commandBus = commandBus;
            _indicatorReader = indicatorReader;
        }

        [HttpGet("{code}", Name = "GetIndicator")]
        public async Task<IActionResult> GetIndicator(string code)
        {
            return new OkObjectResult(await _indicatorReader.GetIndicatorByCodeAsync(code));
        }

        [HttpPost]
        public async Task<IActionResult> CreateIndicator([FromBody] CreateIndicatorCommand command)
        {
            await _commandBus.SubmitAsync(command);
            return CreatedAtRoute("GetIndicator", new { code = command.Code }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIndicator(Guid id, [FromBody] UpdateIndicatorCommand command)
        {
            command.Id = id;
            await _commandBus.SubmitAsync(command);
            return new OkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIndicator(Guid id)
        {
            await _commandBus.SubmitAsync(new DeleteIndicatorCommand() { Id = id });
            return new EmptyResult();
        }

        [HttpGet("{id}/measures")]
        public Task<IActionResult> GetIndicatorMeasures(Guid id)
        {
            return null;
        }

        [HttpPost("{id}/measures")]
        public async Task<IActionResult> CreateIndicatorMeasure(Guid id, [FromBody] CreateIndicatorMeasureCommand command)
        {
            command.IndicatorId = id;
            await _commandBus.SubmitAsync(command);
            return new OkResult();
        }

        [HttpPut("{id}/measures/{measureId}")]
        public Task<IActionResult> UpdateIndicatorMeasure(Guid id, Guid measureId, [FromBody] UpdateIndicatorMeasureCommand command)
        {
            //command.IndicatorId = id;
            //await _commandBus.SubmitAsync(command);
            return null;
        }

        [HttpDelete("{id}/measures/{measureId}")]
        public Task<IActionResult> DeleteIndicatorMeasure(Guid id, Guid measureId)
        {
            //await _commandBus.SubmitAsync(new DeleteIndicatorCommand() { Id = id });
            return null;
        }
    }
}