

using BackEnd.Core.Models;

namespace BackEnd.Bussines.BcaClie.Interface;

public interface IBcaClieService
{
    Task<BcaClieEntity> CreatedorUpdateAsync(BcaClieEntity entity);
}
