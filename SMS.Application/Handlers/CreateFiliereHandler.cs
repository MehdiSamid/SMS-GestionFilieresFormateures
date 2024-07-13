using MediatR;
using SMS.Application.Commands;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;

namespace SMS.Application.Handlers
{
    public class CreateFiliereHandler : IRequestHandler<CreateFiliereCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateFiliereHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Filiere> Handle(CreateFiliereCommand request, CancellationToken cancellationToken)
        {
            var filiere = new Filiere
            {
                NomFiliere = request.NomFiliere,
                Description = request.Description,
                Niveau = request.Niveau,
                Duree = request.Duree,
                Capacite = request.Capacite,
                FraisInscription = request.FraisInscription,
                MontantMensuel = request.MontantMensuel,
                MontantAnnuel = request.MontantAnnuel,
                MontantTrimestre = request.MontantTrimestre,
            };

            await _unitOfWork.FiliereRepository.AddAsync(filiere);
            await _unitOfWork.SaveChangesAsync();

            return filiere;
        }

        Task<Guid> IRequestHandler<CreateFiliereCommand, Guid>.Handle(CreateFiliereCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
