using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS.Domain.Interfaces
{
    public interface ISecteurRepository
    {
        Task<Secteur> AddAsync(Secteur secteur);
        Task<Secteur> GetByIdAsync(Guid id);
        Task<IEnumerable<Secteur>> GetAllAsync();
        Task UpdateAsync(Secteur secteur);
        Task DeleteAsync(Guid id);
    }
}
