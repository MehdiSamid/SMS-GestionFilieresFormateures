using MediatR;

namespace SMS.Application.Queries.Emplois
{
    public class GetAllEmploisQuery : IRequest<IEnumerable<Domain.Entities.Emploi>>
    {
    }
}
