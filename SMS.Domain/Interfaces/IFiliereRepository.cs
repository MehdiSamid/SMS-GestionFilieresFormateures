using SMS.Domain.Entities;

namespace SMS.Domain.Interfaces
{
        public interface IFiliereRepository
        {
                Task<Filiere> AddAsync(Filiere filiere);
                Task<Filiere> GetByIdAsync(Guid id);
                Task<Filiere> Find(Guid id);
                Task<IEnumerable<Filiere>> GetAllAsync();
                Task<Filiere> DeleteAsync(Guid id);

                //Task DeleteAsync(Filiere filiere);

                Task UpdateAsync(Filiere filiere);
        }

}