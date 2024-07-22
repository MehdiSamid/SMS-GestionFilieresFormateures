using MediatR;
using System;

namespace SMS.Application.Commands.Absences
{
    public class CreateAbsenceCommand : IRequest<Guid>
    {
        public Guid IdSeance { get; set; }
        public Guid IdFormateur { get; set; }
        public string IdStagaire { get; set; }
    }
}
