using System.Collections.Generic;
using System.Threading.Tasks;
using FlightManager.Domain.Data;
using FlightManager.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightManager.Domain.Controllers
{
    [Route("Airplane")]
    public class AirplaneController : ControllerBase
    {

        // [Route("List")]
        [HttpGet]
        public async Task<ActionResult<List<Airplane>>> GetAll([FromServices] DataContext context)
        {
            var aiplanes = await context.Aiplanes.AsNoTracking().ToListAsync();
            return Ok(aiplanes);
        }

        [HttpPost]
        public async Task<ActionResult<List<Airplane>>> Create(
            [FromBody] Airplane model,
            [FromServices] DataContext context
            )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                context.Aiplanes.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = $"Nao foi possivel adicionar o plano de voo MSG: {ex.Message}" });
            }

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