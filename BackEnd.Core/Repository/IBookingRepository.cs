
using BackEnd.Core.Models;

namespace BackEnd.Core.Repository;

public interface IBookingRepository
{
    Task CreateAsync(BookingEntity model);
    Task<List<BookingEntity>> GetAllAsync();
    Task UpdateAsync(BookingEntity model);
    Task DeleteAsync(BookingEntity model);
    IQueryable<BookingEntity> List();
    Task<BookingEntity?> GetSupplierConfirmedAsync(string supplierId);
}
