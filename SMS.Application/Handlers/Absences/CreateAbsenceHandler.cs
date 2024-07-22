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
        private readonly IFormateurRepository _formateurRepository;
        private readonly ISeanceRepository _seanceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAbsenceHandler(IAbsenceRepository absenceRepository, IUnitOfWork unitOfWork , IFormateurRepository formateurRepository , ISeanceRepository seanceRepository)
        {
            _absenceRepository = absenceRepository;
            _unitOfWork = unitOfWork;
            _formateurRepository = formateurRepository;
            _seanceRepository = seanceRepository;
        }

        public async Task<Guid> Handle(CreateAbsenceCommand request, CancellationToken cancellationToken)
        {
            var formateur = await _formateurRepository.GetByIdAsync(request.IdFormateur);
            if (formateur == null)
            {
                throw new Exception($"Formateur with ID {request.IdFormateur} not found.");
            }
            var seance = await _seanceRepository.GetByIdAsync(request.IdSeance);
            if (seance == null)
            {
                throw new Exception($"Seance with ID {request.IdSeance} not found.");
            }
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
