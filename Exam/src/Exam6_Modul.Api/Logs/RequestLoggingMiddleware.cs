using Serilog;
using System.Diagnostics;
using ILogger = Serilog.ILogger;

namespace Exam6_Modul.Api.Logs;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            _logger.Information("Handling {Method} {Path}", context.Request.Method, context.Request.Path);
            await _next(context);
            sw.Stop();
            _logger.Information("Handled {Method} {Path} responded {StatusCode} in {Elapsed}ms", context.Request.Method, context.Request.Path, context.Response.StatusCode, sw.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            sw.Stop();
            _logger.Error(ex, "Request {Method} {Path} failed after {Elapsed}ms", context.Request.Method, context.Request.Path, sw.ElapsedMilliseconds);
            throw;
        }
    }
}
