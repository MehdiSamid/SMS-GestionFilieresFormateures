using MediatR;
using SMS.Application.Commands.Seances;
using SMS.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SMS.Application.Handlers.Seances
{
    public class DeleteSeanceHandler : IRequestHandler<DeleteSeanceCommand, Unit>
    {
        private readonly ISeanceRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSeanceHandler(ISeanceRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteSeanceCommand request, CancellationToken cancellationToken)
        {
            var seance = await _repository.GetByIdAsync(request.Id);
            if (seance == null)
            {
                throw new Exception($"Seance with ID {request.Id} not found.");
            }

            seance.DeletedAt = DateTime.UtcNow;
            seance.IsDeleted = true;
            await _repository.UpdateAsync(seance);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
