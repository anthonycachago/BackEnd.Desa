

using System;

namespace BackEnd.Core.Models;

public class BookingEntity
{
    public string? BookingId { get; set; }
    public string? Status  { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset StartAt { get; set; }
    public string Currency { get; set; } = "USD";
    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public string? SupplierId { get; set; }
    public string? RatePlan { get; set; }
    public string? PaymentMethod { get; set; }
    public string? CustomerEmail { get; set; }

}
