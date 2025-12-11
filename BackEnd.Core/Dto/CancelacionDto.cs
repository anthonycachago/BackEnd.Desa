

namespace BackEnd.Core.Dto;

public class CancelacionDto
{

    public string? BookingId { get; set; }
    public string? EventType { get; set; } = "CANCELLATION RECORDED";
   
    public DateTimeOffset CancelAt { get; set; }

    public bool SupplierNotified { get; set; }
    public string? Notes { get; set; }
    public string? Actor { get; set; }
    public string? Reason { get; set; }


}
