using SMS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Services
{
        public interface IFiliereService
        {
            
        Task<IEnumerable<FiliereDto>> GetFilieresByUnitOfFormationNameAsync(string unitName);
    }

    }

