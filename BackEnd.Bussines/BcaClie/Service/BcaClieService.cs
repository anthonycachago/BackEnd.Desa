

using BackEnd.Bussines.BcaClie.Interface;
using BackEnd.Core.Models;
using BackEnd.Core.Repository;
using Microsoft.Extensions.Logging;

namespace BackEnd.Bussines.BcaClie.Service;

public class BcaClieService: IBcaClieService
{
    private readonly IBcaClieRepository _repository;
    private readonly ILogger<BcaClieService> _logger;

    public BcaClieService(IBcaClieRepository bcaClieRepository,ILogger<BcaClieService> logger)
    {
       _repository=bcaClieRepository;
        _logger=logger;
    }
    public async Task<BcaClieEntity> CreatedorUpdateAsync(BcaClieEntity entity)
    {
        try
        {
            if (entity.ClieCodTcli <= 0)
                throw new ArgumentException("El tipo de cliente es obligatorio");

            BcaClieEntity? existente = null;

            if (entity.ClieNumClie.HasValue)
            {
                existente = await _repository.GetByTipoYNumeroAsync(
                    entity.ClieCodTcli,
                    entity.ClieNumClie.Value);
            }

            if (existente == null)
            {
                _logger.LogInformation("Creando cliente. TipoCliente={TipoCliente}", entity.ClieCodTcli);
                await _repository.CreateAsync(entity);
                return entity;
            }
            else
            {
                // Actualizar campos editables
                existente.ClieApeClie = entity.ClieApeClie;
                existente.ClieNomClie = entity.ClieNomClie;
                existente.ClieDirDomi = entity.ClieDirDomi;
                existente.ClieEmaClie = entity.ClieEmaClie;
                existente.ClieEstClie = entity.ClieEstClie;
                existente.ClieCalClie = entity.ClieCalClie;
                existente.ClieFecUac = DateTime.Now;

                await _repository.UpdateAsync(existente);

                _logger.LogInformation(
                    "Cliente actualizado. TipoCliente={TipoCliente}, Numero={Numero}",
                    entity.ClieCodTcli,
                    entity.ClieNumClie);

                return existente;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al guardar cliente");
            throw;
        }
    }



}
