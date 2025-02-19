
using System.Text;
using Newtonsoft.Json;
using TelexApm.Models;

namespace TelexApm.Services;


internal class BaseTracker
{
    private readonly HttpClient _httpClient;

    protected virtual TelexConfiguration _config { get; set; }

    public BaseTracker()
    {
        _httpClient = new();
    }

    public async Task Track(WebhookPayload payload, string _channelHookId)
    {
        var payloadJson = JsonConvert.SerializeObject(payload);

        var content = new StringContent(payloadJson, Encoding.UTF8, "application/json");

        var _ = await _httpClient.PostAsync($"https://{_config.BaseUrl}/{_config.ChannelHookId}", content);

        // return JsonConvert.DeserializeObject<SuccessResponse>(responseContent);
    }
}