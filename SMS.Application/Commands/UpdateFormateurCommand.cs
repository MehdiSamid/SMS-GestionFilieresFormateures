// SMS.Application/Commands/UpdateFormateurCommand.cs
using MediatR;
using System;

namespace SMS.Application.Commands
{
    public record UpdateFormateurCommand(Guid Id,
                                         string Nom,
                                         string Prenom,
                                         string Email,
                                         string Telephone,
                                         string Type,
                                         string Specialisation,
                                         string Statut) : IRequest<Unit>;
}
