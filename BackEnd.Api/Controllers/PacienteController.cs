using BackEnd.Core.Models;
using BackEnd.Infrastructure.Paciente;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController:ControllerBase
    {
        private readonly UnitOfWorkPaciente _server;

        public PacienteController(UnitOfWorkPaciente unitOfWorkPaciente)
        {
            _server = unitOfWorkPaciente;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pacientes = await _server.pacienteRepository.GetAllAsync();

            if (pacientes == null || !pacientes.Any())
            {
                return NotFound();
            }

            return Ok(pacientes);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PacienteEntity entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Email) || !entity.Email.Contains("@"))
            {
                return BadRequest(new { success = false, message = "El email del paciente es inválido o está incompleto." });
            }


            var creado =  _server.pacienteRepository.CreateAsync(entity);

            if (creado == null)
            {
                return StatusCode(500, new { success = false, message = "No se pudo crear el paciente." });
            }

            return Ok(new { success = true, data = creado });
        }




    }
}
