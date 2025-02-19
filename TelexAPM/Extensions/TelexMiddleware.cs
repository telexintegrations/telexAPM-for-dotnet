using Microsoft.AspNetCore.Http;
using TelexApm.Services;

namespace TelexApm.Extensions;


public class TelexMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly ITelexClient _telexClient;

    public TelexMiddleWare(RequestDelegate next, ITelexClient telexClient)
    {
        _next = next;
        _telexClient = telexClient;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var startTime = DateTime.UtcNow;

        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await _telexClient.TrackErrorAsync(ex);
            throw;
        }
        finally
        {
            await _telexClient.TrackPerformanceAsync("HTTP Request Speed", DateTime.UtcNow - startTime);
        }
    }
}