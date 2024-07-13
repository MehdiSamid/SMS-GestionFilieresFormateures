using MediatR;
using SMS.Application.Commands;
using SMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Handlers
{
    public class UpdateFiliereHandler : IRequestHandler<updateFiliereCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFiliereHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(updateFiliereCommand request, CancellationToken cancellationToken)
        {
            var filiere = await _unitOfWork.FiliereRepository.GetByIdAsync(request.Id);

            if (filiere == null)
            {
                throw new Exception("Filiere not found");
            }

            filiere.NomFiliere = request.NomFiliere;
            filiere.Description = request.Description;
            filiere.Niveau = request.Niveau;
            filiere.Duree = request.Duree;
            filiere.Capacite = request.Capacite;
            filiere.FraisInscription = request.FraisInscription;
            filiere.MontantMensuel = request.MontantMensuel;
            filiere.MontantAnnuel = request.MontantAnnuel;
            filiere.MontantTrimestre = request.MontantTrimestre;

            _unitOfWork.FiliereRepository.UpdateAsync(filiere);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
