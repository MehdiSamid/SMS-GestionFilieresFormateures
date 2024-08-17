using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
    public class Emploi : BaseEntity
    {
        public DateTime dateEmploi { get; set; }
        public string groupe { get; set; }
        public string semestre { get; set; }

        [ForeignKey(nameof(filiere))]
        public Guid filiereId { get; set; }
        public Filiere filiere { get; set; }

        public Guid IdGroupe { get; set; }
        public int nbrSeance { get;set; }
        public DateTime breakStart { get; set; }
        public DateTime breakEnd { get; set; }

        public int breakRange { get; set; }

        public int SeanceDuration { get; set; }

        public DateTime firstSeanceStart { get; set;}

        /*
        
        IdFiliere, IdGroupe, SeanceDuration, nbrSeance, breakTime (the time of the break ina w9ita), breakRange(nbr minute of break), StartingTime

         */
    }
}
