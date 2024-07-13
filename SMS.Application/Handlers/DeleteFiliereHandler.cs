using MediatR;
using SMS.Application.Commands;
using SMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Handlers
{
    public class DeleteFiliereHandler : IRequestHandler<DeleteFiliereCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork ;

        public DeleteFiliereHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ;
        }

        public async Task<Unit> Handle(DeleteFiliereCommand request, CancellationToken cancellationToken)
        {
            var filiere = await _unitOfWork.FiliereRepository.GetByIdAsync(request.id);

            if (filiere == null)
            {
                throw new Exception("Filiere not found");
            }

            await _unitOfWork.FiliereRepository.DeleteAsync(filiere);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
