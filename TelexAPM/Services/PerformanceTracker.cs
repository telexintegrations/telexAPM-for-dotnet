using Newtonsoft.Json;
using TelexApm.Models;
namespace TelexApm.Services;

public interface IPerformanceTracker
{
    Task TrackAsync(string MetricName, TimeSpan duration);
}

internal class PerformanceTracker : BaseTracker, IPerformanceTracker
{

    public PerformanceTracker(TelexConfiguration config)
        : base()
    {
        _config = config;
    }

    public async Task TrackAsync(string metricName, TimeSpan duration)
    {

    }
}

