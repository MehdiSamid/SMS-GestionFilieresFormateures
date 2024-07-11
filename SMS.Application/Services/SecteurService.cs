using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.Application.DTOs;
using SMS.Domain.Entities;
using SMS.Infrastructure; // Replace with your actual namespace for DbContext
using Microsoft.EntityFrameworkCore;
using System;

namespace SMS.Application.Services
{
    public class SecteurService
    {
        private readonly FiliereDbContext _context;
        private readonly IMapper _mapper;

        public SecteurService(FiliereDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Secteur> GetAllSecteurs()
        {
            return _context.Secteurs.ToList(); // Use correct DbSet property name
        }

        public Secteur GetSecteurById(Guid id)
        {
            return _context.Secteurs.FirstOrDefault(s => s.Id == id); // Use correct DbSet property name
        }

        public void AddSecteur(Secteur secteur)
        {
            _context.Secteurs.Add(secteur); // Use correct DbSet property name
            _context.SaveChanges();
        }

        public void UpdateSecteur(Secteur secteur)
        {
            _context.Entry(secteur).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteSecteur(Secteur secteur)
        {
            _context.Secteurs.Remove(secteur); // Use correct DbSet property name
            _context.SaveChanges();
        }
    }
}
