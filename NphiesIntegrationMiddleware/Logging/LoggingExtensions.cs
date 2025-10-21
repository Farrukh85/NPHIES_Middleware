using Serilog;

namespace NphiesIntegrationMiddleware.Logging;

public static class LoggingExtensions
{
    public static void ConfigureSerilog(WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        builder.Host.UseSerilog(Log.Logger, dispose: true);
    }
}
