using Exam.Application.DTOs;
using AutoMapper;
using Exam.Domain.Entities;

namespace Exam.Application.Mappings
{
    public class SportProfile : Profile
    {
        public SportProfile()
        {
            CreateMap<Sport, SportDto>().ReverseMap();
            CreateMap<Sport, CreateSportDto>().ReverseMap();
        }
    }
}
