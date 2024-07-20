using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Interfaces
{
    public interface ISeanceRepository
    {
        Task<Seance> AddAsync(Seance seance);
        Task<Seance> GetByIdAsync(Guid id);
        Task<IEnumerable<Seance>> GetAllAsync();
        Task<Seance> UpdateAsync(Seance seance);
        Task DeleteAsync(Guid id);
    }
}
