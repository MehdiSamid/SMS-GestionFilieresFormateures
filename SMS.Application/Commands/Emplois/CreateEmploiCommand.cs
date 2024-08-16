using MediatR;
using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Commands.Emplois
{
    public class CreateEmploiCommand : IRequest<Guid>
    {
        public DateTime dateEmploi { get; set; }
        public string groupe { get; set; }
        public string semestre { get; set; }
        public Guid filiereId { get; set; }
        public Guid IdGroupe { get; set; }
        public int nbrSeance { get; set; }
        public DateTime breakStart { get; set; }
        public DateTime breakEnd { get; set; }

        // Computed property
        public int breakRange { get; set; }
    }
}
