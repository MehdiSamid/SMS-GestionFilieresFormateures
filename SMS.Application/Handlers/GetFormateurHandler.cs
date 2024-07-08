using MediatR;
using SMS.Application.Queries;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System;


namespace SMS.Application.Handlers
{
    public class GetFormateurHandler : IRequestHandler<GetFormateurQuery, Formateur>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFormateurHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Formateur> Handle(GetFormateurQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.FormateurRepository.GetByIdAsync(request.Id);
        }
    }

}
