using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Interfaces
{
    public interface IEmploiRepository
    {
        Task<Emploi> AddAsync(Emploi seance);
        Task<Emploi> GetByIdAsync(Guid id);
        Task<IEnumerable<Emploi>> GetAllAsync();
        Task<Emploi> UpdateAsync(Emploi emploi);
        Task DeleteAsync(Guid id);
    }
}
