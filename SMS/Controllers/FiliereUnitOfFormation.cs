using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.Application.DTOs;
using SMS.Domain.Entities;

[ApiController]
[Route("api/[controller]")]
public class FiliereUnitOfFormationController : ControllerBase
{
    private readonly FiliereDbContext _context;

    public FiliereUnitOfFormationController(FiliereDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FiliereUnitOfFormation>>> Get()
    {
        return await _context.FiliereUnitOfFormations.ToListAsync();
    }

    [HttpGet("{filiereId}/{unitOfFormationId}")]
    public async Task<ActionResult<FiliereUnitOfFormation>> Get(Guid filiereId, Guid unitOfFormationId)
    {
        var filiereUnitOfFormation = await _context.FiliereUnitOfFormations
            .FindAsync(filiereId, unitOfFormationId);

        if (filiereUnitOfFormation == null)
        {
            return NotFound();
        }

        return filiereUnitOfFormation;
    }

    [HttpPost]
    public async Task<ActionResult<FiliereUnitOfFormation>> Post(FiliereUnitOfFormationDto dto)
    {
        var filiereUnitOfFormation = new FiliereUnitOfFormation
        {
            FiliereId = dto.FiliereId,
            UnitOfFormationId = dto.UnitOfFormationId
        };

        _context.FiliereUnitOfFormations.Add(filiereUnitOfFormation);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { filiereId = dto.FiliereId, unitOfFormationId = dto.UnitOfFormationId }, filiereUnitOfFormation);
    }

    [HttpPut("{filiereId}/{unitOfFormationId}")]
    public async Task<IActionResult> Put(Guid filiereId, Guid unitOfFormationId, FiliereUnitOfFormationDto dto)
    {
        if (filiereId != dto.FiliereId || unitOfFormationId != dto.UnitOfFormationId)
        {
            return BadRequest();
        }

        var filiereUnitOfFormation = await _context.FiliereUnitOfFormations
            .FindAsync(filiereId, unitOfFormationId);

        if (filiereUnitOfFormation == null)
        {
            return NotFound();
        }

        // Update properties if necessary
        // filiereUnitOfFormation.SomeProperty = dto.SomeProperty;

        _context.Entry(filiereUnitOfFormation).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{filiereId}/{unitOfFormationId}")]
    public async Task<IActionResult> Delete(Guid filiereId, Guid unitOfFormationId)
    {
        var filiereUnitOfFormation = await _context.FiliereUnitOfFormations
            .FindAsync(filiereId, unitOfFormationId);

        if (filiereUnitOfFormation == null)
        {
            return NotFound();
        }

        _context.FiliereUnitOfFormations.Remove(filiereUnitOfFormation);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
