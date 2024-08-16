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
    public class EmploiRepository : IEmploiRepository
    {
        private readonly FiliereDbContext _context;
        public EmploiRepository(FiliereDbContext context)
        {
            _context = context;
        }
        public async Task<Emploi> AddAsync(Emploi emploi)
        {
            await _context.Emplois.AddAsync(emploi);
            await _context.SaveChangesAsync();
            return emploi;
        }

        public async Task DeleteAsync(Guid id)
        {
            var emploi = await _context.Emplois.FindAsync(id);
            if (emploi != null)
            {
                emploi.DeletedAt = DateTime.UtcNow;
                emploi.IsDeleted = true;
                _context.Emplois.Update(emploi);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Emploi>> GetAllAsync()
        {
            return await _context.Emplois.Where(a => !a.IsDeleted && a.DeletedAt == null).ToListAsync();
        }

        public async Task<Emploi> GetByIdAsync(Guid id)
        {
            return await _context.Emplois.FindAsync(id);
        }

        public async Task<Emploi> UpdateAsync(Emploi emploi)
        {
            _context.Emplois.Update(emploi);
            await _context.SaveChangesAsync();
            return emploi;
        }
    }
}
