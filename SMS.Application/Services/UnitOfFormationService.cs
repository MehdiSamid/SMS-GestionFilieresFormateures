//using SMS.Application.DTOs.UnitOfFormations;
//using SMS.Application.Mapping;
//using SMS.Domain.Entities;
//using SMS.Domain.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace SMS.Application.Services
//{
//    public interface IUnitOfFormationService
//    {
//        Task<IEnumerable<UnitOfFormationDto>> GetAllAsync();
//        Task<UnitOfFormationDto> GetByIdAsync(Guid id);
//        Task<IEnumerable<UnitOfFormationDto>> GetByIdFiliereAsync(Guid idFiliere);
//        Task<UnitOfFormationDto> AddAsync(AddUnitofFormationDto unitDto);
//        Task UpdateAsync(UnitOfFormationDto unitDto);
//        Task DeleteAsync(Guid id);
//    }

//    public class UnitOfFormationService : IUnitOfFormationService
//    {
//        private readonly IUnitOfFormationRepository _repository;
//        private readonly FiliereDbContext _context;

//        public UnitOfFormationService(FiliereDbContext context, IUnitOfFormationRepository repository)
//        {
//            _context = context;
//            _repository = repository;
//        }

//        public async Task<IEnumerable<UnitOfFormationDto>> GetAllAsync()
//        {
//            var units = await _repository.GetAllAsync();
//            return units.Select(UnitOfFormationProfile.ToDto);
//        }

//        public async Task<UnitOfFormationDto> GetByIdAsync(Guid id)
//        {
//            var unit = await _repository.GetByIdAsync(id);
//            return unit == null ? null : UnitOfFormationProfile.ToDto(unit);
//        }

//        public async Task<IEnumerable<UnitOfFormationDto>> GetByIdFiliereAsync(Guid idFiliere)
//        {
//            var units = await _repository.GetByIdFiliereAsync(idFiliere);
//            return units.Select(UnitOfFormationProfile.ToDto);
//        }

//        public async Task UpdateAsync(UnitOfFormationDto unitDto)
//        {
//            var unit = UnitOfFormationProfile.ToEntity(unitDto);
//            await _repository.UpdateAsync(unit);
//        }

//        public async Task DeleteAsync(Guid id)
//        {
//            await _repository.DeleteAsync(id);
//        }

//        public async Task<UnitOfFormationDto> AddAsync(AddUnitofFormationDto unitDto)
//        {
//            try
//            {
//                var unit = UnitOfFormationProfile.ToEntity(unitDto);
//                await _context.UnitOfFormations.AddAsync(unit);
//                await _context.SaveChangesAsync();

//                var unitDtoResult = UnitOfFormationProfile.ToDto(unit);
//                return unitDtoResult;
//            }
//            catch (Exception ex)
//            {
//                // Log the exception (ex) here if needed
//                return new UnitOfFormationDto
//                {
//                    // You can include additional fields to indicate the error if necessary
//                    // Message = "An error occurred while adding the unit of formation."
//                };
//            }
//        }
//    }
//}
