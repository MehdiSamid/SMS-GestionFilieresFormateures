using SMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS.Domain.Interfaces
{
    public interface ISecteurRepository
    {
        Task<Secteur> AddAsync(Secteur secteur);
        Task<Secteur> GetByIdAsync(int id);
        Task<IEnumerable<Secteur>> GetAllAsync();
        Task UpdateAsync(Secteur secteur); // Add method for updating
        Task DeleteAsync(int id); // Add method for deleting
        // Other methods as needed...
    }
}
