using MediatR;
using System;

namespace SMS.Application.Commands.Emplois
{
    public class UpdateEmploiCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public DateTime dateEmploi { get; set; }
        public string groupe { get; set; }
        public string semestre { get; set; }
    }
}
