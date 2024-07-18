using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Interfaces
{
    public interface IAbsenceRepository
    {
        Task<Absence> AddAsync(Absence absence);
        Task<Absence> GetByIdAsync(Guid id);
        Task<IEnumerable<Absence>> GetAllAsync();
        Task<Absence> UpdateAsync(Absence absence);
        Task DeleteAsync(Guid id);
    }
}
