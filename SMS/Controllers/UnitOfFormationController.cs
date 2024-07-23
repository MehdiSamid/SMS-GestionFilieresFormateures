using Microsoft.AspNetCore.Mvc;
using SMS.Application.DTOs.UnitOfFormations;
using SMS.Application.Services;
using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitOfFormationController : ControllerBase
    {
        private readonly IUnitOfFormationService _service;
        private readonly FiliereDbContext _context;
        private readonly IFiliereService _filiereService;

        public UnitOfFormationController(IUnitOfFormationService service, IFiliereService filiereService , FiliereDbContext context)
        {
            _service = service;
            _filiereService = filiereService;
            _context = context;
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
                return NotFound($"UnitOfFormation with ID {id} not found");
            }
            return Ok(unit);
        }

        [HttpGet("byFiliere/{idFiliere}")]
        public async Task<ActionResult<IEnumerable<UnitOfFormationDto>>> GetUnitsOfFormationByIdFiliere(Guid idFiliere)
        {
            var units = await _service.GetByIdFiliereAsync(idFiliere);
            return Ok(units);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(AddUnitofFormationDto unitDto)
        //{
        //    var createdUnit = await _service.AddAsync(unitDto);
        //    return CreatedAtAction(nameof(GetUnitOfFormationById), new { id = createdUnit.Id }, createdUnit);
        //}
        [HttpPost]
        public async Task<IActionResult> Create(AddUnitofFormationDto unitDto)
        {
            var unitOfFormation = new UnitOfFormation
            {
                Name = unitDto.Name,
                Semestre = unitDto.Semestre,
                Duration = unitDto.Duration,
                Coefficient = unitDto.Coefficient
            };

            _context.UnitOfFormations.Add(unitOfFormation);
            await _context.SaveChangesAsync();

            var filiereUnitOfFormation = new FiliereUnitOfFormation
            {
                FiliereId = unitDto.FiliereId,
                UnitOfFormationId = unitOfFormation.Id
            };

            _context.FiliereUnitOfFormations.Add(filiereUnitOfFormation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUnitOfFormationById), new { id = unitOfFormation.Id }, unitOfFormation);
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
                return Ok("UnitOfFormation updated successfully");
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"UnitOfFormation with ID {id} not found");
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
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
                return Ok("UnitOfFormation deleted successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return StatusCode(500, $"Failed to delete UnitOfFormation with ID {id}");
            }
        }

        [HttpGet("filieresByUnitOfFormation/{unitName}")]
        public async Task<IActionResult> GetFilieresByUnitOfFormationName(string unitName)
        {
            try
            {
                var filieres = await _filiereService.GetFilieresByUnitOfFormationNameAsync(unitName);
                if (filieres == null || !filieres.Any())
                {
                    return NotFound($"No Filieres found with UnitOfFormation name {unitName}");
                }
                return Ok(filieres);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
