using MediatR;

namespace SMS.Application.Commands
{
    public record DeleteFiliereCommand(Guid id) : IRequest<Unit>;
}