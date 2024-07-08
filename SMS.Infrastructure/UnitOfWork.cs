using SMS.Domain.Interfaces;
using SMS.Infrastructure.Repositories;

namespace SMS.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FiliereDbContext _context;
        private IFormateurRepository _formateurRepository;
        private IFiliereRepository _filiereRepository;

        public UnitOfWork(FiliereDbContext context)
        {
            _context = context;
        }

        public IFormateurRepository FormateurRepository =>
            _formateurRepository ??= new FormateurRepository(_context);

        public IFiliereRepository FiliereRepository =>
            _filiereRepository ??= new FiliereRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
