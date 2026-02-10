

using BackEnd.Core.Models;
using BackEnd.Core.Repository;
using BackEnd.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Repository.BcaUsua;

public class BcaClieRepository : BaseRepository<BcaClieEntity>, IBcaClieRepository
{
    private readonly BackEndContext _dbContext;

    public BcaClieRepository(BackEndContext backEnd) : base(backEnd)
    {

        _dbContext = backEnd;
    }
    public async Task<BcaClieEntity?> GetByTipoYNumeroAsync(
      int clieCodTcli,
      int? clieNumClie)
    {
        if (!clieNumClie.HasValue)
            return null;

        return await List()
            .Where(x =>
                x.ClieCodTcli == clieCodTcli &&
                x.ClieNumClie == clieNumClie)
            .OrderBy(x => x.ClieFecIngr)
            .FirstOrDefaultAsync();
    }



}
