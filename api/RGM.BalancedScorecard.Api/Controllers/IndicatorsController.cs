using Microsoft.AspNetCore.Mvc;
using RGM.BalancedScorecard.Domain.Commands.Indicators;
using RGM.BalancedScorecard.Kernel.Domain.Commands;

namespace RGM.BalancedScorecard.API.Controllers
{
    [Route("api/[controller]")]
    public class IndicatorsController : Controller
    {
        private readonly ICommandBus _commandBus;

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
    }
}