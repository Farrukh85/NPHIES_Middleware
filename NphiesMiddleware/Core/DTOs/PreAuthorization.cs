namespace NphiesMiddleware.Core.DTOs;

public class PreAuthorization
{
    public string? AuthorizationId { get; set; }
    public string? PatientId { get; set; }
    public decimal Amount { get; set; }
}
