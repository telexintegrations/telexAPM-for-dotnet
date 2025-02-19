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
        if (string.IsNullOrEmpty(metricName)) throw new ArgumentNullException(nameof(metricName), "Metric name cannot be empty");

        try
        {
            var performanceReport = new PerformanceReport
            {
                Message = "",
                Duration = duration.ToString(),
            };

            var payload = new WebhookPayload
            {
                EventName = $"{metricName} POST",
                Message = JsonConvert.SerializeObject(performanceReport),
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

