using MediatR;
using SMS.Application.Commands.Seances;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SMS.Application.Handlers.Seances
{
    public class UpdateSeanceHandler : IRequestHandler<UpdateSeanceCommand, Unit>
    {
        private readonly ISeanceRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSeanceHandler(ISeanceRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateSeanceCommand request, CancellationToken cancellationToken)
        {
            var seance = await _repository.GetByIdAsync(request.Id);
            if (seance == null)
            {
                throw new Exception($"Seance with ID {request.Id} not found.");
            }

            seance.IdFiliere = request.IdFiliere;
            seance.IdUniteFormation = request.IdUniteFormation;
            seance.IdGroupe = request.IdGroupe;
            seance.Date = request.Date;
            seance.SeanceIndex = request.SeanceIndex;
            seance.IdSalle = request.IdSalle;
            seance.IdEmploi = request.IdEmploi;
            seance.IdFormateur = request.IdFormateur;

            await _repository.UpdateAsync(seance);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
