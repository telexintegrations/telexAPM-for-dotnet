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

    }
}