using Newtonsoft.Json;
using TelexApm.Models;
namespace TelexApm.Services;

public interface IErrorTracker
{
    // void Track(Exception ex, string channelHookId);
    Task TrackAsync(Exception ex);
}

internal class ErrorTracker : IErrorTracker
{
    private readonly string _channelHookId;
    public ErrorTracker(string channelHookId)
    {
        _channelHookId = channelHookId;
    }

    public async Task TrackAsync(Exception ex)
    {

    }
}