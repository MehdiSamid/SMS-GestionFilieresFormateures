using MediatR;
using SMS.Application.Commands.Absences;
using SMS.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SMS.Application.Handlers.Absences
{
    public class UpdateAbsenceHandler : IRequestHandler<UpdateAbsenceCommand, Unit>
    {
        private readonly IAbsenceRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAbsenceHandler(IAbsenceRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateAbsenceCommand request, CancellationToken cancellationToken)
        {
            var absence = await _repository.GetByIdAsync(request.Id);
            if (absence == null)
            {
                throw new Exception($"Absence with ID {request.Id} not found.");
            }

            absence.idSeance = request.IdSeance;
            absence.idFormateur = request.IdFormateur;
            absence.idStagaire = request.IdStagaire;

            await _repository.UpdateAsync(absence);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
