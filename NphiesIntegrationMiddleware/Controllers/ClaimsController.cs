using Microsoft.AspNetCore.Mvc;
using NphiesIntegrationMiddleware.Models;
using NphiesIntegrationMiddleware.FhirTransform;
using NphiesIntegrationMiddleware.NphiesClient;

namespace NphiesIntegrationMiddleware.Controllers;

[ApiController]
[Route("[controller]")]
public class ClaimsController : ControllerBase
{
    private readonly IFhirTransformer _transformer;
    private readonly INphiesApiClient _client;
    private readonly ILogger<ClaimsController> _logger;

    public ClaimsController(IFhirTransformer transformer, INphiesApiClient client, ILogger<ClaimsController> logger)
    {
        _transformer = transformer;
        _client = client;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitClaim([FromBody] ClaimRequest request)
    {
        _logger.LogInformation("Received claim for member {MemberId}", request.MemberId);
        var fhirJson = _transformer.TransformToFhir(request);
        var response = await _client.PostClaimAsync(fhirJson);
        return StatusCode((int)response.StatusCode);
    }
}
