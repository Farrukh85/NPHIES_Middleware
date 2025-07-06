using System.Net.Http.Headers;

namespace NphiesMiddleware.Integration;

public class OAuthMessageHandler : DelegatingHandler
{
    private readonly IHttpClientFactory _factory;
    private readonly IConfiguration _config;

    public OAuthMessageHandler(IHttpClientFactory factory, IConfiguration config)
    {
        _factory = factory;
        _config = config;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // TODO: Retrieve token from OAuth server
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "token");
        return await base.SendAsync(request, cancellationToken);
    }
}
