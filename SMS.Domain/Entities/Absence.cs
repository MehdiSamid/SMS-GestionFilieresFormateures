using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
    public class Absence : BaseEntity
    {
        public string idSeance { get; set; }
        public string idFormateur { get; set; }
        public string idStagaire { get; set; }
    }
}
