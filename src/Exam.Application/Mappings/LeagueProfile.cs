using Exam.Application.DTOs;
using AutoMapper;
using Exam.Domain.Entities;

namespace Exam.Application.Mappings;

public class LeagueProfile : Profile
{
    public LeagueProfile()
    {
        CreateMap<League, LeagueDto>().ReverseMap();
        CreateMap<League, CreateLeagueDto>().ReverseMap();
    }
}

