﻿using AutoMapper;
using global::SMS.Application.DTOs.SMS.Application.DTOs;
using global::SMS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Services;
namespace SMS.Controllers
{


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

            // Other action methods
        }
    

}
