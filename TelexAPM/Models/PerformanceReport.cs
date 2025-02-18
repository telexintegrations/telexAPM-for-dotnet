using Newtonsoft.Json;
namespace TelexApm.Models;

public class PerformanceReport
{
    [JsonProperty("message")]
    public string Message { get; set; }


    [JsonProperty("timestamp")]
    public string Duration { get; set; }

}