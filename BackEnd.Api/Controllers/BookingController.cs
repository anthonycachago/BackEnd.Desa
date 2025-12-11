using BackEnd.Core.Models;
using BackEnd.Infrastructure.Repository.Booking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Api.Controllers;
[Authorize]
[ApiController]
[Route("api/bookings")]
public class BookingController:ControllerBase
{
    private readonly UnitOfWorkBooking _server;

    public BookingController(UnitOfWorkBooking server )
    {
           _server= server; 
    }

    [HttpGet("supplierid/{supplierid}")]
    public async Task<IActionResult> Getsupplierid(string supplierid)
    {
        var sup = await _server.BookingRepository.GetSupplierConfirmedAsync(supplierid);

        if (sup == null )
        {
            return NotFound(new { message = "La reserva no existe o está CANCELADA." });
        }

        return Ok(sup);
    }
    [HttpPost]
    public async Task<IActionResult> CancelationBoking([FromBody] BookingEntity entity)
    {
        var creado = _server.BookingRepository.CreateAsync(entity);

        if (creado == null)
        {
            return StatusCode(500, new { success = false, message = "No se pudo ." });
        }

        return Ok(new { success = true, data = creado });
    }
}
