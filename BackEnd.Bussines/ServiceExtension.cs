
using BackEnd.Bussines.BcaClie.Interface;
using BackEnd.Bussines.BcaClie.Service;
using BackEnd.Bussines.BcaUsua.Interface;
using BackEnd.Bussines.BcaUsua.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.Bussines;

public static class ServiceExtension
{
    public static IServiceCollection AddServicesExtension(this IServiceCollection services)
    {
       
        services.AddScoped<IBecaUsuaService, BcaUsuaService> ();
        services.AddScoped<IBcaClieService,BcaClieService> ();
        return services;
    }
}
