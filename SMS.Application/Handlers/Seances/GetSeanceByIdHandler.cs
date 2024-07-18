using MediatR;
using SMS.Application.Queries.Seances;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SMS.Application.Handlers.Seances
{
    public class GetSeanceByIdHandler : IRequestHandler<GetSeanceByIdQuery, Seance>
    {
        private readonly ISeanceRepository _repository;

        public GetSeanceByIdHandler(ISeanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<Seance> Handle(GetSeanceByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
