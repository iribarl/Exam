using Exam.Application.DTOs;
using AutoMapper;
using Exam.Domain.Entities;

namespace Exam.Application.Mappings;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Event, EventDto>().ReverseMap();
        CreateMap<Event, CreateEventDto>().ReverseMap();
    }
}

