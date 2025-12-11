
using BackEnd.Infrastructure.DataBase;
using BackEnd.Infrastructure.Paciente;
using BackEnd.Infrastructure.Repository.AuditEvent;
using BackEnd.Infrastructure.Repository.Booking;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.Infrastructure;

public static class RepositoryExtension
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<UnitOfWorkPaciente>();
        services.AddScoped<UnitOfWorkBooking>();
        services.AddScoped<UnitOfWorkAuditEvent>();
        return services;
    }
    public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration config)
    {
        var backendConnection = config.GetConnectionString("backendConnection");

        services.AddDbContext<BackEndContext>(options =>
            options.UseSqlServer(backendConnection)); // Usa UseSqlServer si estás trabajando con SQL Server

        return services;
    }

}
