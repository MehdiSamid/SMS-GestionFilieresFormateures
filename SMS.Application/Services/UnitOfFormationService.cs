using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SMS.Application.DTOs;
using SMS.Application.Mapping;
using SMS.Domain.Interfaces;

namespace SMS.Application.Services
{
    public interface IUnitOfFormationService
    {
        Task<IEnumerable<UnitOfFormationDto>> GetAllAsync();
        Task<UnitOfFormationDto> GetByIdAsync(Guid id);
        Task<IEnumerable<UnitOfFormationDto>> GetByIdFiliereAsync(Guid idFiliere);
        Task<UnitOfFormationDto> AddAsync(UnitOfFormationDto unitDto);
        Task UpdateAsync(UnitOfFormationDto unitDto);
        Task DeleteAsync(Guid id);
    }

    public class UnitOfFormationService : IUnitOfFormationService
    {
        private readonly IUnitOfFormationRepository _repository;

        public UnitOfFormationService(IUnitOfFormationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UnitOfFormationDto>> GetAllAsync()
        {
            var units = await _repository.GetAllAsync();
            return units.Select(UnitOfFormationProfile.ToDto);
        }

        public async Task<UnitOfFormationDto> GetByIdAsync(Guid id)
        {
            var unit = await _repository.GetByIdAsync(id);
            return unit == null ? null : UnitOfFormationProfile.ToDto(unit);
        }

        public async Task<IEnumerable<UnitOfFormationDto>> GetByIdFiliereAsync(Guid idFiliere)
        {
            var units = await _repository.GetByIdFiliereAsync(idFiliere);
            return units.Select(UnitOfFormationProfile.ToDto);
        }

        public async Task<UnitOfFormationDto> AddAsync(UnitOfFormationDto unitDto)
        {
            var unit = UnitOfFormationProfile.ToEntity(unitDto);
            var createdUnit = await _repository.AddAsync(unit);
            return UnitOfFormationProfile.ToDto(createdUnit);
        }

        public async Task UpdateAsync(UnitOfFormationDto unitDto)
        {
            var unit = UnitOfFormationProfile.ToEntity(unitDto);
            await _repository.UpdateAsync(unit);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
