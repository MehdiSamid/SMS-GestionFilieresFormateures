using MediatR;
using SMS.Application.Queries.Emplois;
using SMS.Application.Queries.Seances;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;

namespace SMS.Application.Handlers.Emplois
{
    public class GetEmploiByIdHandler : IRequestHandler<GetEmploiByIdQuery, Emploi>
    {
        private readonly IEmploiRepository _repository;

        public GetEmploiByIdHandler(IEmploiRepository repository)
        {
            _repository = repository;
        }

        public async Task<Emploi> Handle(GetEmploiByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
