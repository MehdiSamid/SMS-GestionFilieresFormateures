

using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System.Collections.Immutable;

namespace SMS.Infrastructure.Repositories
{
    public class FiliereRepository : FiliereRepositoryBase, IFiliereRepository
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

        public async Task<IEnumerable<Filiere>> GetAllAsync()
        {
            return await _context.Filieres.ToListAsync();
        }

        public async Task<Filiere> DeleteAsync(Guid id)
        {
            var filiereToDelete = await _context.Filieres.FindAsync(id);

            if (filiereToDelete != null)
            {
                _context.Filieres.Remove(filiereToDelete);
                await _context.SaveChangesAsync();
            }

            return filiereToDelete;
        }

        public Task<Filiere> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }

    public class FiliereRepositoryBase
    {
    }
}
