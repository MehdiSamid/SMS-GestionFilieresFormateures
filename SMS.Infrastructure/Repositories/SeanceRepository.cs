using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using SMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repositories
{
    
    public class SeanceRepository : ISeanceRepository
    {
        private readonly FiliereDbContext _context;
        public SeanceRepository(FiliereDbContext context)
        {
            _context = context;
        }
        public async Task<Seance> AddAsync(Seance seance)
        {
            await _context.Seances.AddAsync(seance);
            await _context.SaveChangesAsync();
            return seance;
        }

        public async Task DeleteAsync(Guid id)
        {
            var seance = await _context.Seances.FindAsync(id);
            if (seance != null)
            {
                seance.DeletedAt = DateTime.UtcNow;
                seance.IsDeleted = true;
                _context.Seances.Update(seance);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Seance>> GetAllAsync()
        {
            return await _context.Seances.Where(a => !a.IsDeleted && a.DeletedAt == null).ToListAsync();
        }

        public async Task<Seance> GetByIdAsync(Guid id)
        {
            return await _context.Seances.FindAsync(id);
        }

        public async Task<Seance> UpdateAsync(Seance seance)
        {
            _context.Seances.Update(seance);
            await _context.SaveChangesAsync();
            return seance;
        }
    }
}
