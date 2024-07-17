using MediatR;
using System;
namespace SMS.Application.Commands.Absences
{
    public class DeleteAbsenceCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteAbsenceCommand(Guid id)
        {
            Id = id;
        }
    }
}
