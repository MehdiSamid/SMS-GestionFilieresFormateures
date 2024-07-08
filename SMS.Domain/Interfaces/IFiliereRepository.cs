using SMS.Domain.Entities;

namespace SMS.Domain.Interfaces
{
    public interface IFiliereRepository
    {
        Task<Filiere> AddAsync(Filiere filiere);
        Task<Filiere> GetByIdAsync(int id);
        Task<IEnumerable<Filiere>> GetAllAsync();
        // Other methods as needed...
    }

}