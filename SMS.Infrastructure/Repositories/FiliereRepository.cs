

using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System.Collections.Immutable;

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
            await _context.Filieres.AddAsync(filiere);
            return filiere;
        }

        public async Task<Filiere> GetByIdAsync(int id)
        {
            return await _context.Filieres.FindAsync(id);
        }

        public async Task<IEnumerable<Filiere>> GetAllAsync()
        {
            return await _context.Filieres.ToListAsync();
        }

        public Task<Filiere> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Filiere> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        // Other CRUD methods...
    }

}
