using MediatR;

namespace SMS.Application.Queries.Seances
{
    public class GetAllSeanceQuery : IRequest<IEnumerable<Domain.Entities.Seance>>
    {
    }
}
