using MediatR;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SMS.Application.Commands.Absences
{
    public class CreateAbsenceHandler : IRequestHandler<CreateAbsenceCommand, Guid>
    {
        private readonly IAbsenceRepository _absenceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAbsenceHandler(IAbsenceRepository absenceRepository, IUnitOfWork unitOfWork)
        {
            _absenceRepository = absenceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateAbsenceCommand request, CancellationToken cancellationToken)
        {
            var absence = new Domain.Entities.Absence
            {
                idSeance = request.IdSeance,
                idFormateur = request.IdFormateur,
                idStagaire = request.IdStagaire,
                CreatedAt = DateTime.UtcNow
            };

            await _absenceRepository.AddAsync(absence);
            await _unitOfWork.SaveChangesAsync();

            return absence.Id;
        }
    }
}
