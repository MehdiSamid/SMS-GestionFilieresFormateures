// SMS.Application/Handlers/UpdateFormateurHandler.cs
using MediatR;
using SMS.Application.Commands;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SMS.Application.Handlers
{
    public class UpdateFormateurHandler : IRequestHandler<UpdateFormateurCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFormateurHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateFormateurCommand request, CancellationToken cancellationToken)
        {
            var formateur = await _unitOfWork.FormateurRepository.GetByIdAsync(request.Id);
            if (formateur == null)
            {
                throw new Exception("Formateur not found");
            }

            formateur.Nom = request.Nom;
            formateur.Prenom = request.Prenom;
            formateur.Email = request.Email;
            formateur.Telephone = request.Telephone;
            formateur.Type = request.Type;
            formateur.Specialisation = request.Specialisation;
            formateur.Statut = request.Statut;

            _unitOfWork.FormateurRepository.UpdateAsync(formateur);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
