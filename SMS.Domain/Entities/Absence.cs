using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
    public class Absence : BaseEntity
    {
        public string idSeance { get; set; }
        public Guid idFormateur { get; set; }
        public string idStagaire { get; set; }

        [ForeignKey (nameof(idFormateur))]
        public Formateur Formateur { get; set; }    
    }
}
