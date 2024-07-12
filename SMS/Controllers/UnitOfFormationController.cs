using Microsoft.AspNetCore.Mvc;
using SMS.Application.DTOs;
using SMS.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitOfFormationController : ControllerBase
    {
        private readonly IUnitOfFormationService _service;

        public UnitOfFormationController(IUnitOfFormationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitOfFormationDto>>> GetAllUnitsOfFormation()
        {
            var units = await _service.GetAllAsync();
            return Ok(units);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UnitOfFormationDto>> GetUnitOfFormationById(Guid id)
        {
            var unit = await _service.GetByIdAsync(id);
            if (unit == null)
            {
                return NotFound();
            }
            return Ok(unit);
        }

        [HttpGet("byFiliere/{idFiliere}")]
        public async Task<ActionResult<IEnumerable<UnitOfFormationDto>>> GetUnitsOfFormationByIdFiliere(Guid idFiliere)
        {
            var units = await _service.GetByIdFiliereAsync(idFiliere);
            return Ok(units);
        }

        [HttpPost]
        public async Task<ActionResult<UnitOfFormationDto>> CreateUnitOfFormation(UnitOfFormationDto unitDto)
        {
            var createdUnit = await _service.AddAsync(unitDto);
            return CreatedAtAction(nameof(GetUnitOfFormationById), new { id = createdUnit.Id }, createdUnit);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUnitOfFormation(Guid id, UnitOfFormationDto unitDto)
        {
            if (id != unitDto.Id)
            {
                return BadRequest("ID mismatch between route parameter and object ID");
            }

            try
            {
                await _service.UpdateAsync(unitDto);
            }
            catch (Exception)
            {
                return NotFound($"UnitOfFormation with ID {id} not found");
            }

            return Ok("UnitOfFormation updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnitOfFormation(Guid id)
        {
            var unit = await _service.GetByIdAsync(id);
            if (unit == null)
            {
                return NotFound($"UnitOfFormation with ID {id} not found");
            }

            try
            {
                await _service.DeleteAsync(id);
            }
            catch (Exception)
            {
                return BadRequest($"Failed to delete UnitOfFormation with ID {id}");
            }

            return Ok("UnitOfFormation deleted successfully");
        }
    }
}
