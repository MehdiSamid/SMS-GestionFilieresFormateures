using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs
{
    namespace SMS.Application.DTOs
    {
        public class FormateurDto : BaseEntity
        {
            public Guid Id { get; set; }
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string Email { get; set; }
            public string Telephone { get; set; }
            public string Type { get; set; } // Permanent, Intervenant
            public string Specialisation { get; set; }
            public string Statut { get; set; } // Actif, Inactif
        }
    }

}
