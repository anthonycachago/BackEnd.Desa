using BackEnd.Bussines.BcaUsua.Interface;
using BackEnd.Core.Models;
using BackEnd.Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Api.Controllers.BcaUsua;

[ApiController]
[Route("api/bcausua")]
public class BcaUsuaController: ControllerBase
{
    private readonly IBcaUsuaRepository _repository;
    private readonly IBecaUsuaService _service;

    public BcaUsuaController(IBcaUsuaRepository usuaRepository, IBecaUsuaService becaUsuaService )
	{
        _repository= usuaRepository;
        _service= becaUsuaService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pacientes = await _repository.GetAllAsync();

        if (pacientes == null || !pacientes.Any())
        {
            return NotFound();
        }

        return Ok(pacientes);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BcaUsuaEntity entity)
    {
        if (string.IsNullOrWhiteSpace(entity.UsuaNomUsua))
        {
            return BadRequest(new { success = false, message = "Nombre inválido" });
        }

        await _service.CrearOEditarAsync(entity);

        return Ok(new { success = true });
    }

}
