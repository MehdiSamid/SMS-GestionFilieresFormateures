using MediatR;
using System;

namespace SMS.Application.Commands.Seances
{
    public class DeleteSeanceCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteSeanceCommand(Guid id)
        {
            Id = id;
        }
    }
}
