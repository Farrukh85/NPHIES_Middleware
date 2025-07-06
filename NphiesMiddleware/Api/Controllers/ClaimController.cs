using Microsoft.AspNetCore.Mvc;
using NphiesMiddleware.Core.DTOs;
using NphiesMiddleware.Core.Interfaces;
using Hl7.Fhir.Model;

namespace NphiesMiddleware.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClaimController : ControllerBase
{
    private readonly IValidationService _validator;
    private readonly IFhirTransformerService _transformer;
    private readonly INphiesPostingService _poster;
    private readonly ILogger<ClaimController> _logger;

    public ClaimController(IValidationService validator, IFhirTransformerService transformer, INphiesPostingService poster, ILogger<ClaimController> logger)
    {
        _validator = validator;
        _transformer = transformer;
        _poster = poster;
        _logger = logger;
    }

    [HttpPost("claims")]
    public async Task<IActionResult> PostClaim([FromBody] ClaimRequest request)
    {
        await _validator.ValidateAsync(request);
        var resource = await _transformer.TransformAsync(request);
        if (resource is Bundle bundle)
        {
            await _poster.PostBundleAsync(bundle);
        }
        _logger.LogInformation("Processed claim {ClaimId}", request.ClaimId);
        return Ok();
    }
}
