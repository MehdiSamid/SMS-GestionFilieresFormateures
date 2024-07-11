using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repositories
{
    // SMS.Infrastructure/Repositories/FormateurRepository.cs
    public class FormateurRepository : IFormateurRepository
    {
        private readonly FiliereDbContext _context;

        public FormateurRepository(FiliereDbContext context)
        {
            _context = context;
        }

        public async Task<Formateur> AddAsync(Formateur formateur)
        {
            await _context.Formateurs.AddAsync(formateur);
            return formateur;
        }

        public async Task<Formateur> GetByIdAsync(Guid id)
        {
            return await _context.Formateurs.FindAsync(id);
        }

        public async Task<IEnumerable<Formateur>> GetAllAsync()
        {
            return await _context.Formateurs.ToListAsync();
        }

        public async Task UpdateAsync(Formateur formateur)
        {
            _context.Formateurs.Update(formateur);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Formateur formateur)
        {
            _context.Formateurs.Remove(formateur);
            await _context.SaveChangesAsync();
        }

        // Other CRUD methods...
    }
}