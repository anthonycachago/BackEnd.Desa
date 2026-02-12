

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
    private const int SaltSize = 16; // 128 bits
    private const int KeySize = 32;  // 256 bits
    private const int Iterations = 100_000;

    public BcaUsuaRepository(BackEndContext backEnd) : base(backEnd)
    {
        _dbContext= backEnd;
       
    }
    public byte[] Hash(string password)
    {
        using var algorithm = new Rfc2898DeriveBytes(
            password,
            SaltSize,
            Iterations,
            HashAlgorithmName.SHA256);

        var salt = algorithm.Salt;
        var key = algorithm.GetBytes(KeySize);

        var hashBytes = new byte[SaltSize + KeySize];

        Buffer.BlockCopy(salt, 0, hashBytes, 0, SaltSize);
        Buffer.BlockCopy(key, 0, hashBytes, SaltSize, KeySize);

        return hashBytes;
    }

    public bool Verify(string password, byte[] hashBytes)
    {
        var salt = new byte[SaltSize];
        var storedKey = new byte[KeySize];

        Buffer.BlockCopy(hashBytes, 0, salt, 0, SaltSize);
        Buffer.BlockCopy(hashBytes, SaltSize, storedKey, 0, KeySize);

        using var algorithm = new Rfc2898DeriveBytes(
            password,
            salt,
            Iterations,
            HashAlgorithmName.SHA256);

        var computedKey = algorithm.GetBytes(KeySize);

        return CryptographicOperations.FixedTimeEquals(computedKey, storedKey);
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
