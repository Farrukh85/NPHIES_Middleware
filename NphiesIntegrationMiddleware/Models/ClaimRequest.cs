namespace NphiesIntegrationMiddleware.Models;

public class ClaimRequest
{
    public string MemberId { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string ServiceDate { get; set; } = string.Empty;
}
