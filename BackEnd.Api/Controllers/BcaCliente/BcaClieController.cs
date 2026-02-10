using AutoMapper;
using BackEnd.Bussines.BcaClie.Interface;
using BackEnd.Core.Dto.BcaClie;
using BackEnd.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Api.Controllers.BcaCliente;

[ApiController]
[Authorize]
[Route("api/client/bcaclie")]

public class BcaClieController : ControllerBase
{
    private readonly IBcaClieService _service;
    private readonly ILogger<BcaClieController> _logger;
    private readonly IMapper _mapper;

    public BcaClieController(IBcaClieService bcaClieService, ILogger<BcaClieController> logger, IMapper mapper)
    {
        _service = bcaClieService;
        _logger = logger;
        _mapper = mapper;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BcaClieCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            //Mapeo automático DTO -> Entity
            var entity = _mapper.Map<BcaClieEntity>(dto);

            var clienteCreado = await _service.CreatedorUpdateAsync(entity);

            return StatusCode(200, clienteCreado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear cliente");
            return StatusCode(500, new { message = "Ocurrió un error al crear el cliente" });
        }
    }
    [HttpGet("debug")]
    [Authorize]
    public IActionResult DebugToken()
    {
        var username = User.Identity?.Name;
        var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
        return Ok(new { username, claims });
    }


}
