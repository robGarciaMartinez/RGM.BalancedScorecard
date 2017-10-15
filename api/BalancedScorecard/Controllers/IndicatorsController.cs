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
        private readonly ICommandHandler<CreateIndicatorCommand> _commandHandler;

        public IndicatorsController(ICommandHandler<CreateIndicatorCommand> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateIndicatorCommand command)
        {
            var guid = Guid.Parse("9404e1f5-dd02-4b99-8c91-859fb6447c1e");
            command.Id = guid;
            await _commandHandler.Execute(command);
            return new OkResult();
        }

        [HttpGet("get")]
        public IActionResult Create(Guid id)
        {
            return new EmptyResult();
        }
    }
}