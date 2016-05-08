namespace RGM.BalancedScorecard.API.Controllers
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNet.Mvc;

    using RGM.BalancedScorecard.Domain.Commands.Indicators;
    using RGM.BalancedScorecard.Query.Model.Indicators;
    using RGM.BalancedScorecard.Query.Readers;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    [Route("api/[controller]")]
    public class IndicatorsController : Controller
    {
        private readonly ICommandBus commandBus;

        private readonly IIndicatorsReader reader;

        public IndicatorsController(ICommandBus commandBus, IIndicatorsReader reader)
        {
            this.commandBus = commandBus;
            this.reader = reader;
        }

        [HttpGet]
        public IEnumerable<IndicatorViewModel> GetIndicators()
        {
            return null;
        }

        [HttpGet("{code}", Name = "GetIndicator")]
        public IndicatorViewModel GetIndicator(string code)
        {
            return this.reader.GetByCode(code);
        }

        [HttpPost]
        public IActionResult CreateIndicator([FromBody] CreateIndicatorCommand command)
        {
            if (command == null)
            {
                return this.HttpBadRequest();
            }

            command.Id = Guid.NewGuid();
            this.commandBus.Submit(command);

            return this.CreatedAtRoute("GetIndicator", new { code = command.Code }, command);
        }

        [HttpPut("{code}")]
        public IActionResult UpdateIndicator(string code, [FromBody] UpdateIndicatorCommand command)
        {
            if (command == null)
            {
                return this.HttpBadRequest();
            }

            command.Id = Guid.NewGuid();
            this.commandBus.Submit(command);
            return this.Ok();
        }

        [HttpDelete("{code}")]
        public IActionResult DeleteIndicator(string code)
        {
            return null;
        }

        [HttpGet("{code}/measures")]
        public IEnumerable<IndicatorMeasureViewModel> GetIndicatorMeasures(string code)
        {
            return new List<IndicatorMeasureViewModel>();
        }

        [HttpPost("{code}/measures")]
        public IActionResult CreateIndicatorMeasure(string code, [FromBody] CreateIndicatorMeasureCommand command)
        {
            return null;
        }

        [HttpPut("{code}/measures/{measureId}")]
        public IActionResult UpdateIndicatorMeasure(string code, [FromBody] UpdateIndicatorMeasureCommand command)
        {
            return null;
        }

        [HttpDelete("{code}/measures/{measureId}")]
        public IActionResult DeleteIndicatorMeasure(string code, Guid measureId)
        {
            return null;
        }
    }
}