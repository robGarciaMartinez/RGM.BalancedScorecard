using Microsoft.AspNetCore.Mvc;
using RGM.BalancedScorecard.Domain.Commands.Indicators;
using RGM.BalancedScorecard.Kernel.Domain.Commands;
using RGM.BalancedScorecard.Query.Readers;
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

        [HttpPost]
        public async Task<IActionResult> CreateIndicator([FromBody] CreateIndicatorCommand command)
        {
            await _commandBus.SubmitAsync(command);
            return CreatedAtRoute("GetIndicator", new { code = command.Code }, null);
        }

        [HttpGet("{code}", Name = "GetIndicator")]        
        public async Task<IActionResult> GetIndicator([FromRoute] string code)
        {
            return new OkObjectResult(await _indicatorReader.GetIndicatorByCodeAsync(code));
        }
    }
}