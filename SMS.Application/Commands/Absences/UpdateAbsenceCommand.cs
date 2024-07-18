using MediatR;
using System;

namespace SMS.Application.Commands.Absences
{
    public class UpdateAbsenceCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string IdSeance { get; set; }
        public Guid IdFormateur { get; set; }
        public string IdStagaire { get; set; }
    }
}
