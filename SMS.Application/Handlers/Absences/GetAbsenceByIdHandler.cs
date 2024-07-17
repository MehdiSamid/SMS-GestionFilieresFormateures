using MediatR;
using SMS.Application.Queries.Absence;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SMS.Application.Handlers
{
    public class GetAbsenceByIdHandler : IRequestHandler<GetAbsenceByIdQuery, Domain.Entities.Absence>
    {
        private readonly IAbsenceRepository _repository;

        public GetAbsenceByIdHandler(IAbsenceRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.Absence> Handle(GetAbsenceByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
