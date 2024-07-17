using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using SMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repositories
{
    public class AbsenceRepository : IAbsenceRepository
    {
        private readonly FiliereDbContext _context;

        public AbsenceRepository(FiliereDbContext context)
        {
            _context = context;
        }

        public async Task<Absence> AddAsync(Absence absence)
        {
            await _context.Absences.AddAsync(absence);
            await _context.SaveChangesAsync();
            return absence;
        }

        public async Task<Absence> GetByIdAsync(Guid id)
        {
            return await _context.Absences.FindAsync(id);
        }

        public async Task<IEnumerable<Absence>> GetAllAsync()
        {
            return await _context.Absences.Where(a=> !a.IsDeleted && a.DeletedAt==null).ToListAsync();
        }

        public async Task<Absence> UpdateAsync(Absence absence)
        {
            _context.Absences.Update(absence);
            await _context.SaveChangesAsync();
            return absence;
        }

        public async Task DeleteAsync(Guid id)
        {
            var absence = await _context.Absences.FindAsync(id);
            if (absence != null)
            {
                absence.DeletedAt = DateTime.UtcNow;
                absence.IsDeleted = true;
                _context.Absences.Update(absence);
                await _context.SaveChangesAsync();
            }
        }
    }
}
