using Hl7.Fhir.Model;
using NphiesMiddleware.Core.Interfaces;

namespace NphiesMiddleware.Services;

public class NphiesPostingService : INphiesPostingService
{
    private readonly IHttpClientFactory _factory;
    private readonly ILogger<NphiesPostingService> _logger;

    public NphiesPostingService(IHttpClientFactory factory, ILogger<NphiesPostingService> logger)
    {
        _factory = factory;
        _logger = logger;
    }

    public async Task PostBundleAsync(Bundle bundle)
    {
        var client = _factory.CreateClient("Nphies");
        // TODO: Serialize bundle and post to NPHIES endpoint
        _logger.LogInformation("Posting bundle {Id}", bundle.Id);
        await Task.CompletedTask;
    }
}
