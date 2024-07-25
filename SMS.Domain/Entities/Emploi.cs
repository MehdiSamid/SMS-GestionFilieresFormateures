using System;
using System.Collections.Generic;
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
    }
}
