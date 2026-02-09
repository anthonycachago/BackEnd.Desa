

using BackEnd.Bussines.BcaUsua.Interface;
using BackEnd.Core.Models;
using BackEnd.Core.Repository;

namespace BackEnd.Bussines.BcaUsua.Service;

public class BcaUsuaService: IBecaUsuaService
{
    private readonly IBcaUsuaRepository _repository;

    public BcaUsuaService(IBcaUsuaRepository usuaRepository)
    {
        _repository= usuaRepository;
    }
    public async Task CrearOEditarAsync(BcaUsuaEntity entity)
    {
        var existente = await _repository.GetByUserNameAsync(entity.UsuaNomUsua,entity.UsuaCodEmpl);

        if (existente == null)
        {
            // CREATE
            entity.UsuaPasswd = _repository.Hash(entity.PasswordPlano!);
            entity.PasswordPlano = null;

            await _repository.CreateAsync(entity);
            return;
        }

        // ✏️ UPDATE
        existente.UsuaNomUsua = entity.UsuaNomUsua;
        existente.UsuaCodPerf = entity.UsuaCodPerf;
        existente.UsuaNumAgen = entity.UsuaNumAgen;
        existente.UsuaBanUsua = entity.UsuaBanUsua;

        if (!string.IsNullOrWhiteSpace(entity.PasswordPlano))
        {
            existente.UsuaPasswd = _repository.Hash(entity.PasswordPlano);
        }

        await _repository.UpdateAsync(existente);
    }
    

}
