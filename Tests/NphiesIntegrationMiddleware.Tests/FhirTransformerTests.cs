using NphiesIntegrationMiddleware.FhirTransform;
using NphiesIntegrationMiddleware.Models;

namespace NphiesIntegrationMiddleware.Tests;

public class FhirTransformerTests
{
    [Fact]
    public void TransformToFhir_ReturnsJson()
    {
        var transformer = new FhirTransformer();
        var request = new ClaimRequest { MemberId = "123", Amount = 100, ServiceDate = "2024-01-01" };
        var result = transformer.TransformToFhir(request);
        Assert.Contains("\"resourceType\":\"Claim\"", result);
    }
}
