using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Commands
{
    public record CreateFormateurCommand(string Nom,
                                         string Prenom,
                                         string Email,
                                         string Telephone,
                                         string Type,
                                         string Specialisation,
                                         string Statut) : IRequest<Guid>;

}
