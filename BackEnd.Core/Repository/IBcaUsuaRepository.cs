

using BackEnd.Core.Models;

namespace BackEnd.Core.Repository;

public interface IBcaUsuaRepository : IModelBaseRepository<BcaUsuaEntity>
{
    Task<BcaUsuaEntity?> GetByUserNameAsync(string userName, int usuaCodEmpl);
    byte[] Hash(string password);
    bool Verify(string password, byte[] hash);
}
