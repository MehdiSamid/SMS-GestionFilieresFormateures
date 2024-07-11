using MediatR;
using SMS.Domain.Entities;

namespace SMS.Application.Queries
{
    public record GetSecteurQuery(int Id) : IRequest<Secteur>;
}
