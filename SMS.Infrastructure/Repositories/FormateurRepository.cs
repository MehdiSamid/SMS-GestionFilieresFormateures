using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repositories
{
    public class FormateurRepository : IFormateurRepository
    {
        private readonly FiliereDbContext _context;

        public FormateurRepository(FiliereDbContext context)
        {
            _context = context;
        }

        public async Task<Formateur> AddAsync(Formateur formateur)
        {
            await _context.Formateurs.AddAsync(formateur);
            return formateur;
        }

        public async Task<Formateur> GetByIdAsync(int id)
        {
            return await _context.Formateurs.FindAsync(id);
        }

        public async Task<IEnumerable<Formateur>> GetAllAsync()
        {
            return await _context.Formateurs.ToListAsync();
        }

        public Task<Formateur> Update(int id)
        {
            throw new NotImplementedException();
        }



        // Other CRUD methods...
    }

}
