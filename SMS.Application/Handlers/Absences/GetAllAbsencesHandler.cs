using MediatR;
using SMS.Application.Queries.Absences;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;

namespace SMS.Application.Handlers
{
    public class GetAllAbsencesHandler : IRequestHandler<GetAllAbsencesQuery, IEnumerable<Absence>>
    {
        private readonly IAbsenceRepository _repository;

        public GetAllAbsencesHandler(IAbsenceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Absence>> Handle(GetAllAbsencesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
