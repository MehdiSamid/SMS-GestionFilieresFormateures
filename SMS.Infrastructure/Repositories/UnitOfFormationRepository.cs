using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repositories
{
    public class UnitOfFormationRepository : IUnitOfFormationRepository
    {
        private readonly FiliereDbContext _context;

        public UnitOfFormationRepository(FiliereDbContext context)
        {
            _context = context;
        }

        public async Task<UnitOfFormation> AddAsync(UnitOfFormation unitOfFormation)
        {
            _context.UnitOfFormations.Add(unitOfFormation);
            await _context.SaveChangesAsync();
            return unitOfFormation;
        }

        public async Task<UnitOfFormation> GetByIdAsync(Guid id)
        {
            return await _context.UnitOfFormations.FindAsync(id);
        }

        public async Task<IEnumerable<UnitOfFormation>> GetAllAsync()
        {
            return await _context.UnitOfFormations.ToListAsync();
        }

        public async Task<IEnumerable<UnitOfFormation>> GetByIdFiliereAsync(Guid idFiliere)
        {
            return await _context.UnitOfFormations.Where(u => u.IdFiliere == idFiliere).ToListAsync();
        }

        public async Task<UnitOfFormation> UpdateAsync(UnitOfFormation unitOfFormation)
        {
            _context.UnitOfFormations.Update(unitOfFormation);
            await _context.SaveChangesAsync();
            return unitOfFormation;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.UnitOfFormations.FindAsync(id);
            if (entity != null)
            {
                _context.UnitOfFormations.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<UnitOfFormation> GetUnitOfFormationByNameAsync(string name)
        {
            return await _context.UnitOfFormations.FirstOrDefaultAsync(u => u.Name == name);
        }
    }
}
