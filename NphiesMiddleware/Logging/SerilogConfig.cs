using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace NphiesMiddleware.Logging;

public static class SerilogConfig
{
    public static void ConfigureSerilog(HostBuilderContext ctx, LoggerConfiguration config)
    {
        config.MinimumLevel.Debug()
              .Enrich.FromLogContext()
              .WriteTo.Console()
              .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
              .WriteTo.Seq(ctx.Configuration.GetValue<string>("Logging:SeqUrl"));
    }
}
