using MediatR;
namespace SMS.Application.Commands
{
    public record updateFiliereCommand
    (
        Guid Id, string NomFiliere, string Description, string Niveau, int Duree, int Capacite, decimal FraisInscription, decimal MontantMensuel, decimal MontantAnnuel, decimal MontantTrimestre
    ) : IRequest<Unit>;

    //public class updateFiliereCommand
    //{
    //    public string NomFiliere { get; set; }
    //    public string Description { get; set; }
    //    public string Niveau { get; set; }
    //    public int Duree { get; set; }
    //    public int Capacite { get; set; }
    //    public decimal FraisInscription { get; set; }
    //    public decimal MontantMensuel { get; set; }
    //    public decimal MontantAnnuel { get; set; }
    //    public decimal MontantTrimestre { get; set; }
    //}
}

//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SMS.Application.Commands
//{
//    public record CreateFiliereCommand(string NomFiliere,
//                                         string Description,
//                                         string Niveau,
//                                         int Duree,
//                                         int Capacite,
//                                         decimal FraisInscription,
//                                         decimal MontantMensuel,
//                                         decimal MontantAnnuel,
//                                         decimal MontantTrimestre) : IRequest<Guid>;
//}