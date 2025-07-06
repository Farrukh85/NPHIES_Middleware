using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using NphiesMiddleware.Core.Interfaces;

namespace NphiesMiddleware.Services;

public class FhirTransformerService : IFhirTransformerService
{
    public Task<Resource> TransformAsync<T>(T dto)
    {
        // TODO: Implement mapping from DTO to FHIR Resource
        return Task.FromResult<Resource>(new Bundle());
    }
}
