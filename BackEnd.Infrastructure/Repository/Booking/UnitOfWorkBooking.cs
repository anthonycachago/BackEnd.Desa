

using BackEnd.Core.Repository;
using BackEnd.Infrastructure.DataBase;
using BackEnd.Infrastructure.Paciente;

namespace BackEnd.Infrastructure.Repository.Booking;


public class UnitOfWorkBooking
{
    private readonly BackEndContext _dbContext;

    public UnitOfWorkBooking(BackEndContext backEndContext)
    {
        _dbContext = backEndContext;
        BookingRepository = new BookingRepository(backEndContext);
    }
    public async Task<bool> Save()
    {
        bool isSuccess = await _dbContext.SaveChangesAsync() > 0;
        return isSuccess;
    }
    public void Dispose()
    {
        if (_dbContext == null) return;
        _dbContext.Dispose();

    }
    public readonly IBookingRepository BookingRepository;
}