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

        public IndicatorsController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        public IActionResult CreateIndicator([FromBody] CreateIndicatorCommand command)
        {
            _commandBus.Submit(command);
            return CreatedAtRoute("GetIndicator", new { code = command.Code }, null);
        }

        [HttpGet]
        public async Task<ActionResult> GetIndicator(string code)
        {
            return new OkObjectResult(await _indicatorReader.GetIndicatorByCodeAsync(code));
        }
    }
}