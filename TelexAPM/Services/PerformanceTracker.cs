using Newtonsoft.Json;
using TelexApm.Models;
namespace TelexApm.Services;

public interface IPerformanceTracker
{
    Task TrackAsync(string MetricName, TimeSpan duration);
}

internal class PerformanceTracker : IPerformanceTracker
{
    private readonly string _channelHookId;

    public PerformanceTracker(string channelHookId)
    {
        _channelHookId = channelHookId;
    }

    public async Task TrackAsync(string metricName, TimeSpan duration)
    {

    }
}

