

using BackEnd.Core.Repository;
using BackEnd.Infrastructure.DataBase;
using BackEnd.Infrastructure.Repository.Booking;

namespace BackEnd.Infrastructure.Repository.AuditEvent;


public class UnitOfWorkAuditEvent
{
    private readonly BackEndContext _dbContext;

    public UnitOfWorkAuditEvent(BackEndContext backEndContext)
    {
        _dbContext = backEndContext;
        AuditEventRepository = new AuditEventRepository(backEndContext);
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
    public readonly IAuditEventRepository AuditEventRepository;
}