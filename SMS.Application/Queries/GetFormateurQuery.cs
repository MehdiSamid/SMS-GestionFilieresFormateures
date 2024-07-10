using MediatR;
using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Queries
{
    public record GetFormateurQuery(Guid Id) : IRequest<Formateur>;

}
