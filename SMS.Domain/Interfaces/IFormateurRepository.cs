using SMS.Domain.Entities;

namespace SMS.Domain.Interfaces
{
    public interface IFormateurRepository
    {
        Task<Formateur> AddAsync(Formateur formateur);
        Task<Formateur> GetByIdAsync(int id);
        Task<IEnumerable<Formateur>> GetAllAsync();
        // Other methods as needed...
    }

}