using NphiesIntegrationMiddleware.FhirTransform;
using NphiesIntegrationMiddleware.NphiesClient;
using NphiesIntegrationMiddleware.Logging;
using Polly;
using Polly.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);
LoggingExtensions.ConfigureSerilog(builder);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IFhirTransformer, FhirTransformer>();

builder.Services
    .AddHttpClient<INphiesApiClient, NphiesApiClient>(client =>
    {
        client.BaseAddress = new Uri("https://api.nphies.example.com");
    })
    .AddPolicyHandler(GetRetryPolicy())
    .AddPolicyHandler(GetCircuitBreakerPolicy());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();

static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .WaitAndRetryAsync(3, retryAttempt =>
            TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
}

static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
}
