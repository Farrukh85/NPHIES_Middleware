using Hl7.Fhir.Model;
using NphiesMiddleware.Core.DTOs;

namespace NphiesMiddleware.Transformers;

public static class ClaimFhirTransformer
{
    public static Bundle ToFhir(ClaimRequest request)
    {
        // TODO: map ClaimRequest to FHIR Claim Bundle
        return new Bundle();
    }
}
