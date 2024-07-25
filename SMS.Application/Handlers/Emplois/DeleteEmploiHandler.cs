using MediatR;
using SMS.Application.Commands.Emplois;
using SMS.Application.Commands.Seances;
using SMS.Domain.Interfaces;

namespace SMS.Application.Handlers.Emplois
{
    public class DeleteEmploiHandler : IRequestHandler<DeleteEmploiCommand, Unit>
    {
        private readonly IEmploiRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEmploiHandler(IEmploiRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteEmploiCommand request, CancellationToken cancellationToken)
        {
            var emploi = await _repository.GetByIdAsync(request.Id);
            if (emploi == null)
            {
                throw new Exception($"Seance with ID {request.Id} not found.");
            }

            emploi.DeletedAt = DateTime.UtcNow;
            emploi.IsDeleted = true;
            await _repository.UpdateAsync(emploi);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
