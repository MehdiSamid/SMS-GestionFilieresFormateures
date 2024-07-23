using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repositories
{
    public class FiliereRepository : IFiliereRepository
    {
        private readonly FiliereDbContext _context;

        public FiliereRepository(FiliereDbContext context)
        {
            _context = context;
        }

        public async Task<Filiere> AddAsync(Filiere filiere)
        {
            _context.Filieres.Add(filiere);
            await _context.SaveChangesAsync();
            return filiere;
        }

        public async Task<Filiere> GetByIdAsync(Guid id)
        {
            return await _context.Filieres.FindAsync(id);
        }

        public async Task<Filiere> Find(Guid id)
        {
            return await _context.Filieres.FindAsync(id);
        }

        public async Task<IEnumerable<Filiere>> GetAllAsync()
        {
            return await _context.Filieres.ToListAsync();
        }

        public async Task<Filiere> DeleteAsync(Guid id)
        {
            var entity = await _context.Filieres.FindAsync(id);
            if (entity != null)
            {
                _context.Filieres.Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }

        public async Task DeleteAsync(Filiere filiere)
        {
            _context.Filieres.Remove(filiere);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Filiere filiere)
        {
            _context.Filieres.Update(filiere);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Filiere>> GetFilieresByUnitOfFormationIdAsync(Guid unitId)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<Filiere>> GetFilieresByUnitOfFormationIdAsync(Guid unitId)
        //{
        //    return await _context.Filieres.Where(f => f.UnitOfFormationId == unitId).ToListAsync();
        //}
    }
}
