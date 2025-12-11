

using BackEnd.Core.Models;

namespace BackEnd.Core.Repository;

public interface IAuditEventRepository
{
    
     Task CreateAsync(AuditEventEntity model);
    Task<List<AuditEventEntity>> GetAllAsync();
    Task UpdateAsync(AuditEventEntity model);
    Task DeleteAsync(AuditEventEntity model);
    IQueryable<AuditEventEntity> List();
    Task<AuditEventEntity?> GetBookingIdAsync(string BookingId);
}
