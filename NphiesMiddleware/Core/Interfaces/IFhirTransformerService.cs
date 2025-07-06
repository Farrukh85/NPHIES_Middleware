using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace NphiesMiddleware.Core.Interfaces;

public interface IFhirTransformerService
{
    Task<Resource> TransformAsync<T>(T dto);
}
