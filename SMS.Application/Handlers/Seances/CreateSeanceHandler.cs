using MediatR;
using SMS.Application.Commands.Seances;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SMS.Application.Handlers.Seances
{
    public class CreateSeanceHandler : IRequestHandler<CreateSeanceCommand, Guid>
    {
        private readonly ISeanceRepository _seanceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSeanceHandler(ISeanceRepository seanceRepository, IUnitOfWork unitOfWork)
        {
            _seanceRepository = seanceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateSeanceCommand request, CancellationToken cancellationToken)
        {
            var seance = new Domain.Entities.Seance
            {
                IdFiliere = request.IdFiliere,
                IdUniteFormation = request.IdUniteFormation,
                IdGroupe = request.IdGroupe,
                Date = request.Date,
                SeanceIndex = request.SeanceIndex,
                IdSalle = request.IdSalle,
                IdEmploi = request.IdEmploi,
                IdFormateur = request.IdFormateur,
                CreatedAt = DateTime.UtcNow
            };

            await _seanceRepository.AddAsync(seance);
            await _unitOfWork.SaveChangesAsync();

            return seance.Id;
        }
    }
}
