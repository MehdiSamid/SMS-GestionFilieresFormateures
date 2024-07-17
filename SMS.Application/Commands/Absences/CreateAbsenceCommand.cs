using MediatR;
using System;

namespace SMS.Application.Commands.Absences
{
    public class CreateAbsenceCommand : IRequest<Guid>
    {
        public string IdSeance { get; set; }
        public string IdFormateur { get; set; }
        public string IdStagaire { get; set; }
    }
}
