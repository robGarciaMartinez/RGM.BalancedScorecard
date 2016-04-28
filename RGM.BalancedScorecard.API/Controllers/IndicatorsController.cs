namespace RGM.BalancedScorecard.API.Controllers
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNet.Mvc;

    using RGM.BalancedScorecard.Domain.Commands.Indicators;
    using RGM.BalancedScorecard.Domain.Repositories;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    [Route("api/[controller]")]
    public class IndicatorsController : Controller
    {
        private readonly ICommandBus commandBus;

        public IndicatorsController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetIndicator")]
        public string Get(int id)
        {
            return "value";
        }
            
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]CreateIndicatorCommand command)
        {
            if (command == null)
            {
                return this.HttpBadRequest();
            }

            command.Id = Guid.NewGuid();
            this.commandBus.Submit(command);

            return this.CreatedAtRoute("GetIndicator", new { id = command.Id }, command);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
