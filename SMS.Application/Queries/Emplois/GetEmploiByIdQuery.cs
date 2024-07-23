using MediatR;

namespace SMS.Application.Queries.Emplois
{
    public class GetEmploiByIdQuery : IRequest<Domain.Entities.Emploi>
    {
        public Guid Id { get; set; }

        public GetEmploiByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
