using Newtonsoft.Json;

namespace TelexApm.Models;

public class WebhookPayload
{
    [JsonProperty("event_name")]
    public string EventName { get; set; }

    [JsonProperty("message")]
    public object Message { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }
}