using AutoMapper;
using global::SMS.Application.DTOs.SMS.Application.DTOs;
using global::SMS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.DTOs;
using SMS.Application.Queries.Results;
using SMS.Application.Services;
namespace SMS.Controllers
{


    [ApiController]
        [Route("api/[controller]")]
        public class FiliereController : ControllerBase
        {
            private readonly FiliereService _filiereService;
            private readonly IMapper _mapper;

            public FiliereController(FiliereService filiereService, IMapper mapper)
            {
                _filiereService = filiereService;
                _mapper = mapper;
            }

            [HttpGet]
            public IActionResult GetFiliere()
            {
                var filiers = _filiereService.GetFiliere();
                var filieresDtos = _mapper.Map<IEnumerable<GetFilieresDto>>(filiers);
                return Ok(filieresDtos);
            }

            [HttpPost]
            public IActionResult CreateFiliere([FromBody] FiliereDto FiliereDto)
            {
                var filiere = _mapper.Map<Filiere>(FiliereDto); 
            _filiereService.AddFiliere(filiere);
                return CreatedAtAction(nameof(GetFiliere), new { FiliereDto = filiere }, FiliereDto);
            }

        // Other action methods
        //[HttpPut("{id}")]
        //public ActionResult UpdateFiliere(Guid id, [FromBody] FiliereDto filiereDto)
        //{
        //    if (id != filiereDto.Id)
        //    {
        //        return BadRequest("ID mismatch");
        //    }

        //    try
        //    {
        //        var filiere = _mapper.Map<Filiere>(filiereDto);
        //        _filiereService.UpdateFiliere(filiere);
        //        return NoContent();
        //    }
        //    catch (KeyNotFoundException)
        //    {
        //        return NotFound();
        //    }
        //}

        [HttpPut("{id}")]
        public IActionResult UpdateFormateur(Guid id, [FromBody] FiliereDto filiereDto)
        {
            var filiere = _mapper.Map<Filiere>(filiereDto);
            filiere.Id = id;
            _filiereService.UpdateFiliere(filiere);
            return NoContent();
        }

        //delete endpoint 
        [HttpDelete("{id}")]
        public ActionResult DeleteFiliere(Guid id)
        {
            try
            {
                _filiereService.DeleteFiliere(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }


    }


}
