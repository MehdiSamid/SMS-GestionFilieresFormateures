using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Commands;
using SMS.Application.Commands.Emplois;
using SMS.Application.Queries;
using SMS.Application.Queries.Emplois;
using SMS.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmploiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmploi([FromBody] CreateEmploiCommand command)
        {
            var id = await _mediator.Send(command);
            //return CreatedAtAction(nameof(GetEmploiById), new { id }, null);
            return CreatedAtAction(nameof(GetEmploiById), new { id }, new { id, emploi = command });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmploiById(Guid id)
        {
            var emploi = await _mediator.Send(new GetEmploiByIdQuery(id));
            if (emploi == null)
            {
                return NotFound();
            }
            return Ok(emploi);
        }

        [HttpGet]
        public async Task<IEnumerable<Emploi>> GetAllEmplois()
        {
            return await _mediator.Send(new GetAllEmploisQuery());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmploi(Guid id, [FromBody] UpdateEmploiCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploi(Guid id)
        {
            await _mediator.Send(new DeleteEmploiCommand(id));
            return Ok();
        }
    }
}
