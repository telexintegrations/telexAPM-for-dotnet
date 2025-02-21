using Newtonsoft.Json;
using TelexApm.Models;
namespace TelexApm.Services;

public interface IErrorTracker
{
    // void Track(Exception ex, string channelHookId);
    Task TrackAsync(Exception ex);
}

internal class ErrorTracker : BaseTracker, IErrorTracker
{
    public ErrorTracker(TelexConfiguration config)
        : base()
    {
        _config = config;
    }

    public async Task TrackAsync(Exception ex)
    {
        ArgumentNullException.ThrowIfNull(ex);

        try
        {

            var errorReport = new ErrorReport
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                Timestamp = DateTime.UtcNow
            };


            var payload = new WebhookPayload
            {
                EventName = ".NET APM",
                Message = JsonConvert.SerializeObject(errorReport),
                Status = "success",
                Username = "channel"
            };

            await Track(payload);
        }
        catch (Exception exception)
        {
            // telex is always meant to succeed as per hng - task req; hence no catch implementation.
            Console.WriteLine(exception);
        }
    }
}