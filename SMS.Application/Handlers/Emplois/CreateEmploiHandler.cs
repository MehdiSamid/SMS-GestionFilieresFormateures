﻿using MediatR;
using SMS.Application.Commands.Emplois;
using SMS.Application.Commands.Seances;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;

namespace SMS.Application.Handlers.Emplois
{
    public class CreateEmploiHandler : IRequestHandler<CreateEmploiCommand, Guid>
    {
        private readonly IEmploiRepository _emploiRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateEmploiHandler(IEmploiRepository emploiRepository, IUnitOfWork unitOfWork)
        {
            _emploiRepository = emploiRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateEmploiCommand request, CancellationToken cancellationToken)
        {
            var emploi = new Domain.Entities.Emploi
            {
                dateEmploi = request.dateEmploi,
                groupe = request.groupe,
                semestre = request.semestre,
                CreatedAt = DateTime.UtcNow
            };

            await _emploiRepository.AddAsync(emploi);
            await _unitOfWork.SaveChangesAsync();

            return emploi.Id;
        }
    }
}
