using MediatR;
using SMS.Application.Commands.Emplois;
using SMS.Application.Commands.Seances;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System.Security.Cryptography;

namespace SMS.Application.Handlers.Emplois
{
    public class CreateEmploiHandler : IRequestHandler<CreateEmploiCommand, Guid>
    {
        private readonly IEmploiRepository _emploiRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateEmploiHandler(IEmploiRepository emploiRepository, IUnitOfWork unitOfWork)
        {
            _emploiRepository = emploiRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateEmploiCommand request, CancellationToken cancellationToken)
        {
            //var breakRange = (int)(request.breakEnd - request.breakStart).TotalMinutes;

            var emploi = new Domain.Entities.Emploi
            {
                dateEmploi = request.dateEmploi,
                groupe = request.groupe,
                semestre = request.semestre,
                filiereId = request.filiereId,
                IdGroupe = request.IdGroupe,
                nbrSeance = request.nbrSeance,
                breakStart = request.breakStart,
                breakEnd = request.breakEnd,
                breakRange = request.breakRange,
                SeanceDuration = request.SeanceDuration,
                firstSeanceStart = request.firstSeanceStart,
                CreatedAt = DateTime.UtcNow
            };

            await _emploiRepository.AddAsync(emploi);
            await _unitOfWork.SaveChangesAsync();

            return emploi.Id;
        }
    }
}
