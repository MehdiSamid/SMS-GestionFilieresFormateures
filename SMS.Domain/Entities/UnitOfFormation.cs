using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
    public class UnitOfFormation : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public Guid IdFiliere { get; set; }
        public int Duration { get; set; }
    }
}
