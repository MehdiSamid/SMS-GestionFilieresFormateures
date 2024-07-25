using MediatR;
using System;
using System.Collections.Generic;
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
    }
}
