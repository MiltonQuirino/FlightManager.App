using System.Collections.Generic;
using System.Threading.Tasks;
using FlightManager.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightManager.Domain.Controllers
{
    [Route("Airplane")]
    public class AirplaneController : ControllerBase
    {

        // [Route("List")]
        [HttpGet]
        public async Task<ActionResult<Airplane>> GetAll()
        {
            return new Airplane();
        }

        [HttpPost]
        public async Task<ActionResult<List<Airplane>>> Create([FromBody] Airplane model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpDelete]
        public string Delete()
        {
            return "ok";
        }

        [HttpPut]
        public string Update()
        {
            return "ok";
        }
    }
}