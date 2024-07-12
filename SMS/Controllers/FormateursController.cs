using AutoMapper;
using global::SMS.Application.DTOs.SMS.Application.DTOs;
using global::SMS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Exceptions;
using SMS.Application.Services;

namespace SMS.Controllers
{
    // SMS/Controllers/FormateurController.cs

    [ApiController]
    [Route("api/[controller]")]
    public class FormateurController : ControllerBase
    {
        private readonly FormateurService _formateurService;
        private readonly IMapper _mapper;

        public FormateurController(FormateurService formateurService, IMapper mapper)
        {
            _formateurService = formateurService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFormateurs()
        {
            var formateurs = _formateurService.GetFormateurs();
            var formateurDtos = _mapper.Map<IEnumerable<FormateurDto>>(formateurs);
            return Ok(formateurDtos);
        }

        [HttpPost]
        public IActionResult CreateFormateur([FromBody] FormateurDto formateurDto)
        {
            var formateur = _mapper.Map<Formateur>(formateurDto);
            _formateurService.AddFormateur(formateur);
            return CreatedAtAction(nameof(GetFormateurs), new { Id = formateur }, formateurDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFormateur(Guid id, [FromBody] FormateurDto formateurDto)
        {
            var formateur = _mapper.Map<Formateur>(formateurDto);
            formateur.Id = id;
            _formateurService.UpdateFormateur(formateur);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFormateur(Guid id)
        {
            try
            {
                _formateurService.DeleteFormateur(id);
                return NoContent(); // Retourner un statut 204 No Content si la suppression est réussie
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message); // Retourner un statut 404 Not Found si le formateur n'est pas trouvé
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne du serveur : {ex.Message}"); // Retourner un statut 500 Internal Server Error pour toute autre erreur
            }
        }

        // Other action methods
    }
}
