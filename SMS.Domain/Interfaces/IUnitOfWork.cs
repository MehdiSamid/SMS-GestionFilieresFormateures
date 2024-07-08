using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFormateurRepository FormateurRepository { get; }
        IFiliereRepository FiliereRepository { get; }
        Task<int> SaveChangesAsync();
    }

}
