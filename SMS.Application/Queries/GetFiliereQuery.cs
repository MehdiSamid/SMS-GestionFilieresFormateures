using MediatR;
using SMS.Application.Queries.Results;
using SMS.Domain.Entities;

namespace SMS.Application.Queries
{
    public record GetFiliereQuery(Guid Id) : IRequest<GetFiliereListResponse>;

}
