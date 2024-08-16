using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Commands.Emplois
{
    public class DeleteEmploiCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteEmploiCommand(Guid id)
        {
            Id = id;
        }
    }
}
