using Newtonsoft.Json;
namespace TelexApm.Models;

public class ErrorReport
{
    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("stackTrace")]
    public string StackTrace { get; set; }

    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; set; }



}