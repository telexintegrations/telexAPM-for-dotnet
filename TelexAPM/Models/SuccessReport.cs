
namespace TelexApm.Models;
public record SuccessResponse
{
    public string Status { get; init; } = "Success";
    public string StatusCode { get; init; } = "200";
    public string Message { get; init; } = "Operation completed successfully.";
    public string TaskId { get; init; } = string.Empty;
}

