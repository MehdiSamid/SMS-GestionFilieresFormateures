using SMS.Domain.Entities; // Include if Secteur entity is defined in SMS.Domain.Entities namespace
using SMS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repositories
{
    public class SecteurRepository : ISecteurRepository
    {
        private readonly FiliereDbContext _dbContext;

        public SecteurRepository(FiliereDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Secteur> AddAsync(Secteur secteur)
        {
            secteur.Id = Guid.NewGuid(); // Generate new GUID for new entity
            _dbContext.Secteurs.Add(secteur);
            await _dbContext.SaveChangesAsync();
            return secteur;
        }

        public async Task<Secteur> GetByIdAsync(Guid id)
        {
            return await _dbContext.Secteurs.FindAsync(id);
        }

        public async Task<IEnumerable<Secteur>> GetAllAsync()
        {
            return await _dbContext.Secteurs.ToListAsync();
        }

        public async Task UpdateAsync(Secteur secteur)
        {
            _dbContext.Entry(secteur).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var secteurToDelete = await _dbContext.Secteurs.FindAsync(id);
            if (secteurToDelete != null)
            {
                _dbContext.Secteurs.Remove(secteurToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
