namespace RGM.BalancedScorecard.API.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;

    using Domain.Commands.Indicators;
    using Query.Model.Indicators;
    using Query.Readers;

    using RGM.BalancedScorecard.API.Filters;

    using SharedKernel.Domain.Commands;

    [Route("api/[controller]")]
    [ValidateModelStateFilter]
    public class IndicatorsController : Controller
    {
        private readonly ICommandBus commandBus;

        private readonly IIndicatorsReader reader;

        public IndicatorsController(ICommandBus commandBus, IIndicatorsReader reader)
        {
            this.commandBus = commandBus;
            this.reader = reader;
        }

        //[HttpGet]
        //public IEnumerable<IndicatorViewModel> GetIndicators()
        //{
        //    return null;
        //}

        [HttpGet("{code}", Name = "GetIndicator")]
        public IndicatorViewModel GetIndicator(string code)
        {
            return this.reader.GetByCode(code);
        }

        [HttpPost]    
        public IActionResult CreateIndicator([FromBody] CreateIndicatorCommand command)
        {
            this.commandBus.Submit(command);
            return this.CreatedAtRoute("GetIndicator", new { code = command.Code }, null);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateIndicator(Guid id, [FromBody] UpdateIndicatorCommand command)
        {
            command.Id = id;
            this.commandBus.Submit(command);
            return this.Ok();
        }

        //[HttpDelete("{id}")]
        //public IActionResult DeleteIndicator(Guid id)
        //{
        //    this.commandBus.Submit(new DeleteIndicatorCommand() { Id = id });
        //    return new StatusCodeResult((int)HttpStatusCode.NoContent);
        //}

        //[HttpGet("{id}/measures")]
        //public IEnumerable<IndicatorMeasureViewModel> GetIndicatorMeasures(Guid id)
        //{
        //    return new List<IndicatorMeasureViewModel>();
        //}

        //[HttpPost("{id}/measures")]
        //public IActionResult CreateIndicatorMeasure(Guid id, [FromBody] CreateIndicatorMeasureCommand command)
        //{
        //    return null;
        //}

        //[HttpPut("{id}/measures/{measureId}")]
        //public IActionResult UpdateIndicatorMeasure(Guid id, [FromBody] UpdateIndicatorMeasureCommand command)
        //{
        //    return null;
        //}

        //[HttpDelete("{id}/measures/{measureId}")]
        //public IActionResult DeleteIndicatorMeasure(Guid id, Guid measureId)
        //{
        //    return null;
        //}
    }
}