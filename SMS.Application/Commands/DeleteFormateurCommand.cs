// SMS.Application/Commands/DeleteFormateurCommand.cs
using MediatR;
using System;

namespace SMS.Application.Commands
{
    public record DeleteFormateurCommand(Guid Id) : IRequest<Unit>;
}
