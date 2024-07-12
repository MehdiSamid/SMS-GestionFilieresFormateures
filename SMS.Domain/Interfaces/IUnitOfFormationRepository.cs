using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SMS.Domain.Entities;

namespace SMS.Domain.Interfaces
{
    public interface IUnitOfFormationRepository
    {
        Task<UnitOfFormation> AddAsync(UnitOfFormation unitOfFormation);
        Task<UnitOfFormation> GetByIdAsync(Guid id);
        Task<IEnumerable<UnitOfFormation>> GetAllAsync();
        Task<IEnumerable<UnitOfFormation>> GetByIdFiliereAsync(Guid idFiliere);
        Task<UnitOfFormation> UpdateAsync(UnitOfFormation unitOfFormation);
        Task DeleteAsync(Guid id);
    }
}
