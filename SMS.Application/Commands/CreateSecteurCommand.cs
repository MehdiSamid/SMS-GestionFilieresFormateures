using MediatR;

namespace SMS.Application.Commands
{
    public record CreateSecteurCommand(string Name) : IRequest<int>;
}
