using Microsoft.Extensions.Configuration;
using Serilog;

namespace Exam6_Modul.Api.Configurations;

public static class SerilogConfig
{
    public static Serilog.ILogger CreateLogger(IConfiguration configuration)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        return logger;
    }
}
