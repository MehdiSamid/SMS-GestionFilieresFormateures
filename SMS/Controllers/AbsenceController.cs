using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Commands;
using SMS.Application.Commands.Absences;
using SMS.Application.Queries;
using SMS.Application.Queries.Absence;
using SMS.Application.Queries.Absences;
using SMS.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsencesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AbsencesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbsence([FromBody] CreateAbsenceCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAbsenceById), new { id }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbsenceById(Guid id)
        {
            var absence = await _mediator.Send(new GetAbsenceByIdQuery(id));
            if (absence == null)
            {
                return NotFound();
            }
            return Ok(absence);
        }

         [HttpGet]
        public async Task<IEnumerable<Absence>> GetAllAbsences()
        {
            return await _mediator.Send(new GetAllAbsencesQuery());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAbsence(Guid id, [FromBody] UpdateAbsenceCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbsence(Guid id)
        {
            await _mediator.Send(new DeleteAbsenceCommand(id));
            return Ok();
        }
    }
}
