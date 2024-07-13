﻿using AutoMapper;
using global::SMS.Application.DTOs.SMS.Application.DTOs;
using SMS.Application.DTOs;
using SMS.Domain.Entities;


namespace SMS.Application.Mapping
{

    namespace SMS.Application.Mapping
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<Formateur, FormateurDto>().ReverseMap();
                CreateMap<Filiere, FiliereDto>().ReverseMap();
            }
        }
    }

}
