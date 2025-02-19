using TelexApm.Models;
namespace TelexApm.Services;


public interface ITelexClient
{
    Task<SuccessResponse> TrackErrorAsync(Exception ex);
    Task<SuccessResponse> TrackPerformanceAsync(string metricName, TimeSpan duration);

}


public class TelexConfiguration
{
    public string ChannelHookId { get; set; }
    public string BaseUrl { get; set; }
}



public class TelexClient : ITelexClient
{
    private readonly ErrorTracker _errorTracker;
    private readonly PerformanceTracker _performanceTracker;

    private readonly TelexConfiguration _config;


    public TelexClient(TelexConfiguration config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));

        _errorTracker = new(_config);
        _performanceTracker = new(_config);

    }


    public async Task<SuccessResponse> TrackErrorAsync(Exception ex)
    {
        await _errorTracker.TrackAsync(ex);
        return new SuccessResponse();
    }


    public async Task<SuccessResponse> TrackPerformanceAsync(string metricName, TimeSpan duration)
    {
        await _performanceTracker.TrackAsync(metricName, duration);
        return new SuccessResponse();
    }
};


