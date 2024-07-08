using AutoMapper;
using SMS.Application.Commands;
using SMS.Application.DTOs.SMS.Application.DTOs;
using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Mapping
{
    public class FormateurProfile : Profile
    {
        public FormateurProfile()
        {
            CreateMap<Formateur, FormateurDto>();
            CreateMap<CreateFormateurCommand, Formateur>();
        }
    }

}
