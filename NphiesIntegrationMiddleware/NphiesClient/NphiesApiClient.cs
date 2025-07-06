using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NphiesIntegrationMiddleware.NphiesClient;

public interface INphiesApiClient
{
    Task<HttpResponseMessage> PostClaimAsync(string fhirJson);
}

public class NphiesApiClient : INphiesApiClient
{
    private readonly HttpClient _httpClient;

    public NphiesApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<HttpResponseMessage> PostClaimAsync(string fhirJson)
    {
        var content = new StringContent(fhirJson, Encoding.UTF8, "application/fhir+json");
        return _httpClient.PostAsync("/claims", content);
    }
}
