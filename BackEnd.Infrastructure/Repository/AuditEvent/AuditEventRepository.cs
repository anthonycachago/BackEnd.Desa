using BackEnd.Core.Models;
using BackEnd.Core.Repository;
using BackEnd.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Repository.AuditEvent;

public class AuditEventRepository: IAuditEventRepository
{
    private readonly BackEndContext _db;

    public AuditEventRepository(BackEndContext db)
    {
        _db = db;
    }
    public Task<List<AuditEventEntity>> GetAllAsync()
    {
        return _db.Set<AuditEventEntity>().ToListAsync();
    }

    public async Task CreateAsync(AuditEventEntity entity)
    {
        await _db.Set<AuditEventEntity>().AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(AuditEventEntity entity)
    {
        _db.Entry(entity).State = EntityState.Modified;
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(AuditEventEntity entity)
    {
        _db.Set<AuditEventEntity>().Remove(entity);
        await _db.SaveChangesAsync();
    }

    public async Task<AuditEventEntity?> GetBookingIdAsync(string booking)
    {
        return await _db.Set<AuditEventEntity>()
            .Where(x => x.BookingId == booking)
            .FirstOrDefaultAsync();
    }


    public IQueryable<AuditEventEntity> List()
    {
        return _db.Set<AuditEventEntity>();
    }
}
