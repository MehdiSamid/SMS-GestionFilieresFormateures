using SMS.Domain.Entities;

namespace SMS.Domain.Interfaces
{
    // SMS.Domain/Interfaces/IFormateurRepository.cs
    public interface IFormateurRepository
    {
        Task<Formateur> AddAsync(Formateur formateur);
        Task<Formateur> GetByIdAsync(Guid id);
        Task<IEnumerable<Formateur>> GetAllAsync();
        Task UpdateAsync(Formateur formateur);
        Task DeleteAsync(Formateur formateur);
    }
}