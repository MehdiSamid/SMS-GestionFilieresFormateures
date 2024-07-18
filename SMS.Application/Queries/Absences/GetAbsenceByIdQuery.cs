using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Queries.Absence
{
    public class GetAbsenceByIdQuery : IRequest<Domain.Entities.Absence>
    {
        public Guid Id { get; set; }

        public GetAbsenceByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
