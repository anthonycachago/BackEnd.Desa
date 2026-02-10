using BackEnd.Bussines.Booking.Interface;
using BackEnd.Core.Dto;

using BackEnd.Infrastructure.Repository.AuditEvent;

using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Api.Controllers;

[ApiController]
[Route("api/bookings")]
public class AuditEventController:ControllerBase
{
    private readonly UnitOfWorkAuditEvent _unitofwork;
    private readonly IBookingService _service;

    public AuditEventController(UnitOfWorkAuditEvent unitOfWorkAudit, IBookingService bookingService)
    {
            _unitofwork=unitOfWorkAudit;
        _service=bookingService;
    }
    [HttpPost("{bookingId}/cancel")]
    public async Task<IActionResult> Create([FromRoute] string bookingId,
        [FromBody] CancelacionDto model)
    {
        if (string.IsNullOrWhiteSpace(bookingId))
        {
            return BadRequest(new { success = false, message = "El booking id ." });
        }


        var creado = _service.CancelacionAsync(model, bookingId);

        if (creado == null)
        {
            return StatusCode(500, new { success = false, message = "No se pudo cancelar." });
        }

        return Ok(new { success = true, data = creado });
    }

}
