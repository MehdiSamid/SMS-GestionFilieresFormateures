// SMS.Application/Handlers/DeleteFormateurHandler.cs
using MediatR;
using SMS.Application.Commands;
using SMS.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SMS.Application.Handlers
{
    public class DeleteFormateurHandler : IRequestHandler<DeleteFormateurCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFormateurHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteFormateurCommand request, CancellationToken cancellationToken)
        {
            var formateur = await _unitOfWork.FormateurRepository.GetByIdAsync(request.Id);
            if (formateur == null)
            {
                throw new Exception("Formateur not found");
            }

            await _unitOfWork.FormateurRepository.DeleteAsync(formateur);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
