using TelexApm.Models;
namespace TelexApm.Services;


public interface ITelexClient
{
    Task<SuccessResponse> TrackErrorAsync(Exception ex);
    Task<SuccessResponse> TrackPerformanceAsync(string metricName, TimeSpan duration);

}


public class TelexClient : ITelexClient
{
    private readonly ErrorTracker _errorTracker;
    private readonly PerformanceTracker _performanceTracker;


    public TelexClient(string channelHookId)
    {
        if (string.IsNullOrWhiteSpace(channelHookId)) throw new ArgumentNullException(nameof(channelHookId), "Channel Hook Id is required and cannot be empty");

        _errorTracker = new(channelHookId);
        _performanceTracker = new(channelHookId);

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


