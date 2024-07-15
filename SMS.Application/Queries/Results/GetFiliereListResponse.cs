using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Queries.Results
{
    public class GetFiliereListResponse : BaseEntity
    {
        public string NomFiliere { get; set; }
        public string Description { get; set; }
        public string Niveau { get; set; }
        public int Duree { get; set; }
        public int Capacite { get; set; }
        public decimal FraisInscription { get; set; }
        public decimal MontantMensuel { get; set; }
        public decimal MontantAnnuel { get; set; }
        public decimal MontantTrimestre { get; set; }
    }
}
