using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SMS.Application.DTOs;
using SMS.Domain.Entities;
using SMS.Application.Exceptions;
using SMS.Domain.Interfaces;

namespace SMS.Application.Services
{
    public class FiliereService : IFiliereService
    {
        private readonly FiliereDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfFormationRepository _unitOfFormationRepository;
        private readonly IFiliereRepository _filiereRepository;

        public FiliereService(FiliereDbContext context, IMapper mapper, IUnitOfFormationRepository unitOfFormationRepository, IFiliereRepository filiereRepository)
        {
            _context = context;
            _mapper = mapper;
            _unitOfFormationRepository = unitOfFormationRepository;
            _filiereRepository = filiereRepository;
        }

        public IEnumerable<GetFilieresDto> GetFiliere()
        {
            var filiere = _context.Filieres.ToList();
            return _mapper.Map<IEnumerable<GetFilieresDto>>(filiere);
        }

        public void AddFiliere(Filiere filiere)
        {
            _context.Filieres.Add(filiere);
            _context.SaveChanges();
        }

        public void UpdateFiliere(Filiere filiere)
        {
            _context.Filieres.Update(filiere);
            _context.SaveChanges();
        }

        public void DeleteFiliere(Guid id)
        {
            var filiere = _context.Filieres.Find(id);
            if (filiere == null)
            {
                throw new NotFoundException($"Filiere with ID {id} not found.");
            }

            // Update the DeletedAt property instead of removing the entity
            filiere.DeletedAt = DateTime.UtcNow;
            filiere.IsDeleted = true;

            // Optionally set DeletedBy if applicable
            //filiere.DeletedBy = GetCurrentUserId(); // Replace with logic to get the current user ID

            _context.Filieres.Update(filiere);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<FiliereDto>> GetFilieresByUnitOfFormationNameAsync(string unitName)
        {
            var unit = await _unitOfFormationRepository.GetUnitOfFormationByNameAsync(unitName);
            if (unit == null)
            {
                return Enumerable.Empty<FiliereDto>();
            }

            var filieres = await _filiereRepository.GetFilieresByUnitOfFormationIdAsync(unit.Id);
            return filieres.Select(f => new FiliereDto
            {
                NomFiliere = f.NomFiliere, // Assuming the entity's property is named `Name`
                Description = f.Description,
                Niveau = f.Niveau, // Assuming the entity's property is named `Level`
                Duree = f.Duree, // Assuming the entity's property is named `Duration`
                Capacite = f.Capacite, // Assuming the entity's property is named `Capacity`
                GroupCapacity = f.GroupCapacity,
                FraisInscription = f.FraisInscription, // Assuming the entity's property is named `RegistrationFee`
                MontantMensuel = f.MontantMensuel, // Assuming the entity's property is named `MonthlyAmount`
                MontantAnnuel = f.MontantAnnuel, // Assuming the entity's property is named `AnnualAmount`
                MontantTrimestre = f.MontantTrimestre // Assuming the entity's property is named `QuarterlyAmount`
            });
        }
    }
}
