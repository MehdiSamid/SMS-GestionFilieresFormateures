using MediatR;
using SMS.Application.Queries.Seances;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SMS.Application.Handlers.Seances
{
    public class GetAllSeanceHandler : IRequestHandler<GetAllSeanceQuery, IEnumerable<Seance>>
    {
        private readonly ISeanceRepository _repository;

        public GetAllSeanceHandler(ISeanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Seance>> Handle(GetAllSeanceQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
