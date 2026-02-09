

using BackEnd.Bussines.Booking.Interface;
using BackEnd.Core.Dto;
using BackEnd.Core.Models;
using BackEnd.Infrastructure.Repository.AuditEvent;
using BackEnd.Infrastructure.Repository.Booking;

namespace BackEnd.Bussines.Booking.Service;

public class BookingService: IBookingService
{
    private readonly UnitOfWorkBooking _workBooking;
    private readonly UnitOfWorkAuditEvent _workAuditEvent;

    public BookingService(UnitOfWorkBooking workBooking, UnitOfWorkAuditEvent workAuditEvent )
    {
        _workBooking = workBooking;
        _workAuditEvent= workAuditEvent;
    }
    public async Task<BookingEntity> CancelacionAsync(CancelacionDto model,string BookingId)
    {
        // Buscar el booking
        var bookingEntity = await _workBooking.BookingRepository.GetBookingConfirmedAsync(BookingId!);

        if (bookingEntity == null)
        {
            // No existe el booking
            return null;
        }

        // Cambiar el status
        bookingEntity.Status = "CANCELLED";

        // Actualizar fecha de modificación si quieres llevar control
        bookingEntity.StartAt = bookingEntity.StartAt; // no se cambia, solo ejemplo
        bookingEntity.CreatedAt = bookingEntity.CreatedAt; // idem

        // Guardar cambios
        await _workBooking.BookingRepository.UpdateAsync(bookingEntity);


         // Buscar si ya existe un AuditEvent para este booking
            var bookingIdAuditEvent = await _workAuditEvent.AuditEventRepository.GetBookingIdAsync(BookingId!);

            if (bookingIdAuditEvent == null)
            {
                // Crear nuevo AuditEvent
                var auditEvent = new AuditEventEntity
                {
                    BookingId = BookingId,
                   
                    OccurredAt = DateTimeOffset.UtcNow,
                    CancelAt = model.CancelAt,
                    PenaltyPercent = 0, // aquí puedes calcular según tu lógica
                    PenaltyAmount = 0,  // idem
                    RefundAmount = 0,   // idem
                    SupplierNotified = false,
                    Notes = null,
                    Actor = model.Actor,
                    Reason = model.Reason
                };

                await _workAuditEvent.AuditEventRepository.CreateAsync(auditEvent);
            }
            else
            {
                // Editar AuditEvent existente
                bookingIdAuditEvent.OccurredAt = DateTimeOffset.UtcNow;
                bookingIdAuditEvent.CancelAt = model.CancelAt;
                bookingIdAuditEvent.Actor = model.Actor;
                bookingIdAuditEvent.Reason = model.Reason;
                // puedes recalcular penalidades/refund si aplica
                bookingIdAuditEvent.PenaltyPercent = 0;
                bookingIdAuditEvent.PenaltyAmount = 0;
                bookingIdAuditEvent.RefundAmount = 0;

                await _workAuditEvent.AuditEventRepository.UpdateAsync(bookingIdAuditEvent);
            }
        

        return bookingEntity;
    }
}
