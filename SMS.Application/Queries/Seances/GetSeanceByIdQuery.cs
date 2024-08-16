using MediatR;

namespace SMS.Application.Queries.Seances
{
    public class GetSeanceByIdQuery : IRequest<Domain.Entities.Seance>
    {
        public Guid Id { get; set; }

        public GetSeanceByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
