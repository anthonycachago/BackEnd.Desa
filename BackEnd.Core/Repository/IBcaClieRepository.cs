

using BackEnd.Core.Models;

namespace BackEnd.Core.Repository;

public interface IBcaClieRepository : IModelBaseRepository<BcaClieEntity>
{
    Task<BcaClieEntity?> GetByTipoYNumeroAsync(int clieCodTcli, int? clieNumClie);
}
