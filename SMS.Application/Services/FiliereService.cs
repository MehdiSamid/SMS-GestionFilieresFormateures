using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Application.DTOs;
using SMS.Domain.Entities;
using AutoMapper;
using SMS.Application.DTOs.SMS.Application.DTOs;
using SMS.Application.Exeptions;
namespace SMS.Application.Services
{
    public class FiliereService
    {
        private readonly FiliereDbContext _context;
        private readonly IMapper _mapper;

        public FiliereService(FiliereDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        //public void UpdateFiliere( Filiere updatedFiliere)
        //{
        //    //var existingFiliere = _context.Filieres.Find(id);
        //if (existingFiliere != null)
        //{
        //    existingFiliere.NomFiliere = updatedFiliere.NomFiliere;
        //    existingFiliere.Description = updatedFiliere.Description;
        //    existingFiliere.Niveau = updatedFiliere.Niveau;
        //    existingFiliere.Duree = updatedFiliere.Duree;
        //    existingFiliere.Capacite = updatedFiliere.Capacite;
        //    existingFiliere.FraisInscription = updatedFiliere.FraisInscription;
        //    existingFiliere.MontantMensuel = updatedFiliere.MontantMensuel;
        //    existingFiliere.MontantAnnuel = updatedFiliere.MontantAnnuel;
        //    existingFiliere.MontantTrimestre = updatedFiliere.MontantTrimestre;

        //_context.Filieres.Update(updatedFiliere);
        //_context.SaveChanges();
        //}
        //else
        //{
        //    throw new KeyNotFoundException("Filiere not found");
        //}
        ////}

        public void UpdateFiliere(Filiere filiere)
        {
            _context.Filieres.Update(filiere);
            _context.SaveChanges();
        }
        public void DeleteFiliere(Guid id)
        {
            var Filiere = _context.Filieres.Find(id);
            if (Filiere == null)
            {
                throw new NotFoundException($"Formateur with ID {id} not found.");
            }

            // Update the DeletedAt property instead of removing the entity
            Filiere.DeletedAt = DateTime.UtcNow;
            Filiere.IsDeleted = true;

            // Optionally set DeletedBy if applicable
            //Filiere.DeletedBy = GetCurrentUserId(); // Replace with logic to get the current user ID

            _context.Filieres.Update(Filiere);
            _context.SaveChanges();
        }

    }
}


