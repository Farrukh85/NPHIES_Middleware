using System.Text.Json;
using NphiesIntegrationMiddleware.Models;

namespace NphiesIntegrationMiddleware.FhirTransform;

public interface IFhirTransformer
{
    string TransformToFhir(ClaimRequest request);
}

public class FhirTransformer : IFhirTransformer
{
    public string TransformToFhir(ClaimRequest request)
    {
        // This is a placeholder for real FHIR transformation
        // In a real implementation, map the request to a FHIR resource
        var fhirObject = new
        {
            resourceType = "Claim",
            memberId = request.MemberId,
            amount = request.Amount,
            serviceDate = request.ServiceDate
        };
        return JsonSerializer.Serialize(fhirObject);
    }
}
