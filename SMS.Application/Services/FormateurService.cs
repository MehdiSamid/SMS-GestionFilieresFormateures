using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Application.DTOs;
using SMS.Domain.Entities;
using AutoMapper;
using SMS.Application.DTOs.SMS.Application.DTOs;
namespace SMS.Application.Services
{

   
        public class FormateurService
        {
            private readonly FiliereDbContext _context;
            private readonly IMapper _mapper;

            public FormateurService(FiliereDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public IEnumerable<FormateurDto> GetFormateurs()
            {
                var formateurs = _context.Formateurs.ToList();
                return _mapper.Map<IEnumerable<FormateurDto>>(formateurs);
            }

            public void AddFormateur(Formateur formateur)
            {
                _context.Formateurs.Add(formateur);
                _context.SaveChanges();
            }

            // Other service methods
        }
    }


