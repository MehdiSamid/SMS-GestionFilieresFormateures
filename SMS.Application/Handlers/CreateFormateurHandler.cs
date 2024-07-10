using MediatR;
using SMS.Application.Commands;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;

namespace SMS.Application.Handlers
{
    public class CreateFormateurHandler : IRequestHandler<CreateFormateurCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateFormateurHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Formateur> Handle(CreateFormateurCommand request, CancellationToken cancellationToken)
        {
            var formateur = new Formateur
            {
                Id = Guid.NewGuid(),
                Nom = request.Nom,
                Prenom = request.Prenom,
                Email = request.Email,
                Telephone = request.Telephone,
                Type = request.Type,
                Specialisation = request.Specialisation,
                Statut = request.Statut
            };

            await _unitOfWork.FormateurRepository.AddAsync(formateur);
            await _unitOfWork.SaveChangesAsync();

            return formateur;
        }

        Task<Guid> IRequestHandler<CreateFormateurCommand, Guid>.Handle(CreateFormateurCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
