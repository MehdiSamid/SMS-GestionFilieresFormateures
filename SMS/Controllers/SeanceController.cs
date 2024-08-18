using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Commands;
using SMS.Application.Commands.Seances;
using SMS.Application.Queries;
using SMS.Application.Queries.Seances;
using SMS.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeanceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeance([FromBody] CreateSeanceCommand command)
        {
            var id = await _mediator.Send(command);
            //return CreatedAtAction(nameof(GetSeanceById), new { id }, null);
            return CreatedAtAction(nameof(GetSeanceById), new { id }, new { id, seance = command });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeanceById(Guid id)
        {
            var seance = await _mediator.Send(new GetSeanceByIdQuery(id));
            if (seance == null)
            {
                return NotFound();
            }
            return Ok(seance);
        }

        [HttpGet]
        public async Task<IEnumerable<Seance>> GetAllSeance()
        {
            return await _mediator.Send(new GetAllSeanceQuery());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeance(Guid id, [FromBody] UpdateSeanceCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeance(Guid id)
        {
            await _mediator.Send(new DeleteSeanceCommand(id));
            return Ok();
        }
    }
}
