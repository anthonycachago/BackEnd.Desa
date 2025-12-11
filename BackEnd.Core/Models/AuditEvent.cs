

namespace BackEnd.Core.Models;

public class AuditEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? BookingId { get; set; }
    public string? EventType { get; set; } = "CANCELLATION_RECORDED";
    public DateTimeOffset OccurredAt { get; set; }
    public DateTimeOffset CancelAt { get; set; }
    public decimal PenaltyPercent { get; set; }
    public decimal PenaltyAmount { get; set; }
    public decimal RefundAmount { get; set; }
    public bool SupplierNotified { get; set; }
    public string? Notes { get; set; }
    public string? Actor { get; set; }
    public string? Reason { get; set; }

}
