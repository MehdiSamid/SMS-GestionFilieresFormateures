using SMS.Application.DTOs.UnitOfFormations;
using SMS.Domain.Entities;

namespace SMS.Application.Mapping
{
    public static class UnitOfFormationProfile
    {
        public static UnitOfFormationDto ToDto(UnitOfFormation unit) => new()
        {
            Id = unit.Id,
            Name = unit.Name,
            Semestre = unit.Semestre,
            //IdFiliere = unit.IdFiliere,
            Duration = unit.Duration
        };

        public static UnitOfFormation ToEntity(UnitOfFormationDto unitDto) => new()
        {
            Id = unitDto.Id,
            Name = unitDto.Name,
            Semestre = unitDto.Semestre,
            //IdFiliere = unitDto.IdFiliere,
            Duration = unitDto.Duration
        };

        public static UnitOfFormation ToEntity(AddUnitofFormationDto addUnitDto) => new()
        {
            Name = addUnitDto.Name,
            Semestre = addUnitDto.Semestre,
            //IdFiliere = addUnitDto.IdFiliere,
            Duration = addUnitDto.Duration
        };
    }
}
