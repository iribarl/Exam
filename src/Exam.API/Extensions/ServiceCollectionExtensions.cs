using Exam.Application.DTOs;
using Exam.Application.Interfaces;
using Exam.Application.Mappings;
using Exam.Application.Services;
using Exam.Domain.Entities;
using Exam.Domain.Interfaces;
using Exam.Infrastructure.Context;
using Exam.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Exam.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection collectionServices, string? connectionString)
        {
            collectionServices.AddDbContext<ExamDbContext>(options => options.UseSqlServer(connectionString));

            collectionServices.TryAddScoped(typeof(IRepositoryBase<Sport>), typeof(RepositoryBase<ExamDbContext, Sport>));
            collectionServices.TryAddScoped(typeof(IRepositoryBase<League>), typeof(RepositoryBase<ExamDbContext, League>));
            collectionServices.TryAddScoped(typeof(IRepositoryBase<Event>), typeof(RepositoryBase<ExamDbContext, Event>));

            collectionServices.AddScoped(typeof(IServiceBase<SportDto,Sport>), typeof(ServiceBase<SportDto, Sport>));
            collectionServices.AddScoped(typeof(IServiceBase<LeagueDto, League>), typeof(ServiceBase<LeagueDto, League>));
            collectionServices.AddScoped(typeof(IServiceBase<EventDto, Event>), typeof(ServiceBase<EventDto, Event>));

            return collectionServices;
        }


        public static IServiceCollection RegisterAutoMappings(this IServiceCollection collectionServices)
        {
            collectionServices.AddAutoMapper(typeof(SportProfile));
            collectionServices.AddAutoMapper(typeof(LeagueProfile));
            collectionServices.AddAutoMapper(typeof(EventProfile));
            return collectionServices;
        }
    }
}
