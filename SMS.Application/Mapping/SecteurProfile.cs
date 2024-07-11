using AutoMapper;
using SMS.Application.Commands;
using SMS.Application.DTOs;
using SMS.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SMS.Application.Mapping
{
    public class SecteurProfile : Profile
    {
        public SecteurProfile()
        {
            CreateMap<Secteur, SecteurDto>();
            CreateMap<CreateSecteurCommand, Secteur>();
        }
    }
}
