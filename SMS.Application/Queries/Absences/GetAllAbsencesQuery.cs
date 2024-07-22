using MediatR;


namespace SMS.Application.Queries.Absences
{
    public class GetAllAbsencesQuery : IRequest<IEnumerable<Domain.Entities.Absence>>
    {
    }
}
