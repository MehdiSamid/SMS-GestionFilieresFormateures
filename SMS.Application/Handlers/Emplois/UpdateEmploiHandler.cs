using MediatR;
using SMS.Application.Commands.Emplois;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;

namespace SMS.Application.Handlers.Emplois
{
    public class UpdateEmploiHandler : IRequestHandler<UpdateEmploiCommand, Unit>
    {
        private readonly IEmploiRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEmploiHandler(IEmploiRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateEmploiCommand request, CancellationToken cancellationToken)
        {
            var emploi = await _repository.GetByIdAsync(request.Id);
            if (emploi == null)
            {
                throw new Exception($"Seance with ID {request.Id} not found.");
            }

            emploi.dateEmploi = request.dateEmploi;
            emploi.groupe = request.groupe;
            emploi.semestre = request.semestre;

            await _repository.UpdateAsync(emploi);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
