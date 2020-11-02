using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlightManager.Domain.Data;
using FlightManager.Domain.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Airplane>> Delete(
            [FromServices] DataContext context,
            string id)
        {
            var airplane = await context.Aiplanes.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));

            if (airplane == null)
                return NotFound(new { message = "Aviao não encontrado" });

            context.Aiplanes.Remove(airplane);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public string Update()
        {
            return "ok";
        }
    }
}