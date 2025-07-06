using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace NphiesMiddleware.Core.Interfaces;

public interface INphiesPostingService
{
    Task PostBundleAsync(Bundle bundle);
}
