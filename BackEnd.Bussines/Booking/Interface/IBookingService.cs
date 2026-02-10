

using BackEnd.Core.Dto;
using BackEnd.Core.Models;

namespace BackEnd.Bussines.Booking.Interface;

 public interface IBookingService
{
    Task<BookingEntity> CancelacionAsync(CancelacionDto model,string bookingId);
}
