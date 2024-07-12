using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;

namespace SMS.Infrastructure.Repositories
{
    public class UnitOfFormationRepository : IUnitOfFormationRepository
    {
        private readonly List<UnitOfFormation> _unitsOfFormation = new();

        public async Task<UnitOfFormation> AddAsync(UnitOfFormation unitOfFormation)
        {
            unitOfFormation.Id = Guid.NewGuid();  // Ensure a new ID is assigned
            _unitsOfFormation.Add(unitOfFormation);
            return await Task.FromResult(unitOfFormation);
        }

        public async Task<UnitOfFormation> GetByIdAsync(Guid id)
        {
            var unitOfFormation = _unitsOfFormation.FirstOrDefault(u => u.Id == id);
            return await Task.FromResult(unitOfFormation);
        }

        public async Task<IEnumerable<UnitOfFormation>> GetAllAsync()
        {
            return await Task.FromResult(_unitsOfFormation);
        }

        public async Task<IEnumerable<UnitOfFormation>> GetByIdFiliereAsync(Guid idFiliere)
        {
            var units = _unitsOfFormation.Where(u => u.IdFiliere == idFiliere).ToList();
            return await Task.FromResult(units);
        }

        public async Task<UnitOfFormation> UpdateAsync(UnitOfFormation unitOfFormation)
        {
            var existingUnit = _unitsOfFormation.FirstOrDefault(u => u.Id == unitOfFormation.Id);
            if (existingUnit == null) throw new Exception("UnitOfFormation not found");

            existingUnit.Name = unitOfFormation.Name;
            existingUnit.IdFiliere = unitOfFormation.IdFiliere;
            existingUnit.Duration = unitOfFormation.Duration;

            return await Task.FromResult(existingUnit);
        }

        public async Task DeleteAsync(Guid id)
        {
            var unitOfFormation = _unitsOfFormation.FirstOrDefault(u => u.Id == id);
            if (unitOfFormation == null) throw new Exception("UnitOfFormation not found");

            _unitsOfFormation.Remove(unitOfFormation);
            await Task.CompletedTask;
        }
    }
}
