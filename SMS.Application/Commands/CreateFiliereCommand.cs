using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Commands
{
    public record CreateFiliereCommand(string NomFiliere,
                                         string Description,
                                         string Niveau,
                                         int Duree,
                                         int Capacite,
                                         decimal FraisInscription,
                                         decimal MontantMensuel,
                                         decimal MontantAnnuel,
                                         decimal MontantTrimestre) : IRequest<Guid>;

}
