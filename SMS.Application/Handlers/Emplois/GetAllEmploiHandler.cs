using MediatR;
using SMS.Application.Queries.Emplois;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;

namespace SMS.Application.Handlers.Emplois
{
    public class GetAllEmploiHandler : IRequestHandler<GetAllEmploisQuery, IEnumerable<Emploi>>
    {
        private readonly IEmploiRepository _repository;

        public GetAllEmploiHandler(IEmploiRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Emploi>> Handle(GetAllEmploisQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
