namespace managment_api.Models;

public class ErrorResponse
{
    public string ErrorCode { get; set; }
    public string Message { get; set; }
    public object? Details { get; set; }
}
