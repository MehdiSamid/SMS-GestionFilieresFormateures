using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Application.DTOs;
using SMS.Domain.Entities;
using AutoMapper;
using SMS.Application.DTOs.SMS.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Exceptions;

namespace SMS.Application.Services
{
    // SMS.Application/Services/FormateurService.cs
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

        public void UpdateFormateur(Formateur formateur)
        {
            _context.Formateurs.Update(formateur);
            _context.SaveChanges();
        }

        public void DeleteFormateur(Guid id)
        {
            var formateur = _context.Formateurs.Find(id);
            if (formateur == null)
            {
                throw new NotFoundException($"Formateur with ID {id} not found.");
            }

            _context.Entry(formateur).State = EntityState.Detached; // Détacher l'entité

            _context.Formateurs.Remove(formateur);
            _context.SaveChanges();
        }


        // Other service methods
    }
}