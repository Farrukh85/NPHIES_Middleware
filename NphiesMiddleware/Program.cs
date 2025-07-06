using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Context;
using Serilog.Events;
using NphiesMiddleware.Core.Interfaces;
using NphiesMiddleware.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.Seq(ctx.Configuration.GetValue<string>("Logging:SeqUrl")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NPHIES Middleware API", Version = "v1" });
});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer();

builder.Services.AddHttpClient("Nphies")
    .AddPolicyHandler(HttpPolicies.GetRetryPolicy())
    .AddPolicyHandler(HttpPolicies.GetCircuitBreakerPolicy());

builder.Services.AddScoped<IValidationService, ValidationService>();
builder.Services.AddScoped<IFhirTransformerService, FhirTransformerService>();
builder.Services.AddScoped<INphiesPostingService, NphiesPostingService>();

var app = builder.Build();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

