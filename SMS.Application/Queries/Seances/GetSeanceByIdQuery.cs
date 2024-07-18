using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Queries.Seances
{
    public class GetSeanceByIdQuery : IRequest<Domain.Entities.Seance>
    {
        public Guid Id { get; set; }

        public GetSeanceByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
