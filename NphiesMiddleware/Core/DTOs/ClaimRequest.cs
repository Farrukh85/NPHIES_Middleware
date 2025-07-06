namespace NphiesMiddleware.Core.DTOs;

public class ClaimRequest
{
    public string? ClaimId { get; set; }
    public string? PatientId { get; set; }
    public decimal Amount { get; set; }
}
