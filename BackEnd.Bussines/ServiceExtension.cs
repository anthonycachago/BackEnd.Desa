
using BackEnd.Bussines.Booking.Interface;
using BackEnd.Bussines.Booking.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.Bussines;

public static class ServiceExtension
{
    public static IServiceCollection AddService (this IServiceCollection services)
    {
        services.AddScoped< IBookingService,BookingService> ();
        return services;
    }
}
