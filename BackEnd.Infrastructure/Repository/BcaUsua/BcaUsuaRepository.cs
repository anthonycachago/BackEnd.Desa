

using BackEnd.Core.Models;
using BackEnd.Core.Repository;
using BackEnd.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace BackEnd.Infrastructure.Repository.BcaUsua;

public class BcaUsuaRepository : BaseRepository<BcaUsuaEntity>, IBcaUsuaRepository
{
    private readonly BackEndContext _dbContext;

    public BcaUsuaRepository(BackEndContext backEnd) : base(backEnd)
    {
        _dbContext= backEnd;
    }
    public byte[] Hash(string password)
    {
        using var sha512 = SHA512.Create();
        return sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public bool Verify(string password, byte[] hash)
    {
        var newHash = Hash(password);
        return CryptographicOperations.FixedTimeEquals(newHash, hash);
    }
    public Task<BcaUsuaEntity?> GetByUserNameAsync(string userName, int usuaCodEmpl)
    {
        return _dbContext.Set<BcaUsuaEntity>()
            .FirstOrDefaultAsync(x =>
                x.UsuaNomUsua == userName &&
                x.UsuaCodEmpl == usuaCodEmpl);
    }
    public Task<BcaUsuaEntity?> GetByUserTokenAsyn(string userName)
    {
        return _dbContext.Set<BcaUsuaEntity>()
            .FirstOrDefaultAsync(x =>
                x.UsuaNomUsua == userName);
    }
}
