using BalancedScorecard.Domain.Commands.Indicators;
using BalancedScorecard.Kernel.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BalancedScorecard.Api.Controllers
{
    [Route("api/[controller]")]
    public class IndicatorsController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public IndicatorsController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateIndicatorCommand command)
        {
            command.Id = Guid.NewGuid();
            await _commandDispatcher.Submit(command);
            return new OkResult();
        }

        [HttpGet("get")]
        public IActionResult Create(Guid id)
        {
            return new EmptyResult();
        }
    }
}