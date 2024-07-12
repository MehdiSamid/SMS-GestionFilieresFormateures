using SMS.Application.DTOs;
using SMS.Domain.Entities;

namespace SMS.Application.Mapping
{
    public static class UnitOfFormationProfile
    {
        public static UnitOfFormationDto ToDto(UnitOfFormation unit)
        {
            return new UnitOfFormationDto
            {
                Id = unit.Id,
                Name = unit.Name,
                IdFiliere = unit.IdFiliere,
                Duration = unit.Duration
            };
        }

        public static UnitOfFormation ToEntity(UnitOfFormationDto unitDto)
        {
            return new UnitOfFormation
            {
                Id = unitDto.Id,
                Name = unitDto.Name,
                IdFiliere = unitDto.IdFiliere,
                Duration = unitDto.Duration
            };
        }
    }
}
