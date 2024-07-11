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
            return _context.Secteur.ToList();
        }

        public Secteur GetSecteurById(int id)
        {
            return _context.Secteur.FirstOrDefault(s => s.Id == id);
        }

        public void AddSecteur(Secteur secteur)
        {
            _context.Secteur.Add(secteur);
            _context.SaveChanges();
        }

        public void UpdateSecteur(Secteur secteur)
        {
            _context.Entry(secteur).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //public void DeleteSecteur(Secteur secteur)
        //{
        //    _context.Secteurs.Remove(secteur);
        //    _context.SaveChanges();
        //}
    }
}
