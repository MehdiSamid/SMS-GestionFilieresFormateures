using AutoMapper;
using SMS.Application.Commands;
using SMS.Application.DTOs;
using SMS.Application.DTOs.SMS.Application.DTOs;
using SMS.Application.Queries.Results;
using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Mapping
{
    public class FiliereProfile : Profile
    {
        public FiliereProfile()
        {
            CreateMap<Filiere, FiliereDto>();
            CreateMap<CreateFiliereCommand, Filiere>();
            CreateMap<Filiere, GetFilieresDto>();
        }
    }
}
