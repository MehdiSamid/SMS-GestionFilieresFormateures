using Microsoft.AspNetCore.Mvc;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecteursController : ControllerBase
    {
        private readonly ISecteurRepository _repository;

        public SecteursController(ISecteurRepository repository)
        {
            _repository = repository;
        }

        // GET: api/secteurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Secteur>>> GetAllSecteurs()
        {
            var secteurs = await _repository.GetAllAsync();
            return Ok(secteurs);
        }

        // GET: api/secteurs/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Secteur>> GetSecteurById(Guid id)
        {
            var secteur = await _repository.GetByIdAsync(id);
            if (secteur == null)
            {
                return NotFound();
            }
            return Ok(secteur);
        }

        // POST: api/secteurs
        [HttpPost]
        public async Task<ActionResult<Secteur>> CreateSecteur(Secteur secteur)
        {
            var createdSecteur = await _repository.AddAsync(secteur);
            return CreatedAtAction(nameof(GetSecteurById), new { id = createdSecteur.Id }, createdSecteur);
        }

        // PUT: api/secteurs/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSecteur(Guid id, Secteur secteur)
        {
            if (id != secteur.Id)
            {
                return BadRequest("ID mismatch between route parameter and object ID");
            }

            try
            {
                await _repository.UpdateAsync(secteur);
            }
            catch (Exception)
            {
                return NotFound($"Secteur with ID {id} not found");
            }

            return Ok("Secteur updated successfully");
        }

        // DELETE: api/secteurs/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSecteur(Guid id)
        {
            var secteur = await _repository.GetByIdAsync(id);
            if (secteur == null)
            {
                return NotFound($"Secteur with ID {id} not found");
            }

            try
            {
                await _repository.DeleteAsync(id);
            }
            catch (Exception)
            {
                return BadRequest($"Failed to delete Secteur with ID {id}");
            }

            return Ok("Secteur deleted successfully");
        }
    }
}
