using BackEnd.Bussines.BcaUsua.Interface;
using BackEnd.Core.Dto.BcaUsua;
using BackEnd.Core.Models;
using BackEnd.Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Api.Controllers.BcaUsua;

[ApiController]
[Route("api/user/bcausua")]
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
    //login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] BcaUsuLoginDto loginRequest)
    {
        if (string.IsNullOrWhiteSpace(loginRequest.UsuaNomUsua) ||
            string.IsNullOrWhiteSpace(loginRequest.Password))
        {
            return BadRequest(new
            {
                success = false,
                message = "Nombre de usuario y contraseña son requeridos"
            });
        }

        var usuarioDto = await _service.ValidarCredencialesAsync(
            loginRequest.UsuaNomUsua,
            loginRequest.Password,
            loginRequest.UsuaCodEmpl);

        if (usuarioDto == null)
        {
            return Unauthorized(new
            {
                success = false,
                message = "Credenciales inválidas"
            });
        }

        // 🔽 Mapeo DTO → Entity
        var usuarioEntity = new BcaUsuaEntity
        {
            UsuaNomUsua = usuarioDto.UsuaNomUsua?.Trim()!,
            UsuaCodEmpl = usuarioDto.UsuaCodEmpl
            // NO mapper password / hash
        };

        var token = _service.GenerarTokenConRefresh(usuarioEntity);

        return Ok(new
        {
            success = true,
            token
        });
    }
    [HttpPost("refresh")]
    public IActionResult Refresh([FromBody] RefreshTokenRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var principal = _service.ValidarRefreshToken(request.RefreshToken);
        if (principal == null)
            return Unauthorized("Refresh token inválido o expirado");

        // Obtener username del claim
        var username = principal.Identity?.Name;
        if (string.IsNullOrEmpty(username))
            return Unauthorized("Refresh token inválido");

        // Obtener usuario de la base de datos
        var usuario = _service.GetUser(username).Result; // async puede cambiar a await
        if (usuario == null)
            return Unauthorized("Usuario no encontrado");

        // Generar nuevos tokens
        var tokens = _service.GenerarTokenConRefresh(usuario);

        return Ok(tokens);
    }



}
