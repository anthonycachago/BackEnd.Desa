

using BackEnd.Core.Models;
using BackEnd.Core.Repository;
using BackEnd.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Repository.Booking;

public class BookingRepository: IBookingRepository
{
    private readonly BackEndContext _db;

    public BookingRepository(BackEndContext db)
    {
        _db = db;
    }

    public Task<List<BookingEntity>> GetAllAsync()
    {
        return _db.Set<BookingEntity>().ToListAsync();
    }

    public async Task CreateAsync(BookingEntity entity)
    {
        await _db.Set<BookingEntity>().AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(BookingEntity entity)
    {
        _db.Entry(entity).State = EntityState.Modified;
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(BookingEntity entity)
    {
        _db.Set<BookingEntity>().Remove(entity);
        await _db.SaveChangesAsync();
    }

    public async Task<BookingEntity?> GetSupplierConfirmedAsync(string supplierId)
    {
        return await _db.Set<BookingEntity>()
            .Where(x => x.SupplierId == supplierId && x.Status == "CONFIRMED")
            .FirstOrDefaultAsync();
    }
    public async Task<BookingEntity?> GetBookingConfirmedAsync(string bookingId)
    {
        return await _db.Set<BookingEntity>()
            .Where(x => x.BookingId == bookingId && x.Status == "CONFIRMED")
            .FirstOrDefaultAsync();
    }


    public IQueryable<BookingEntity> List()
    {           
        return _db.Set<BookingEntity>();
    }
}
