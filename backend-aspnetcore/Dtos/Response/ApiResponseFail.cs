namespace BackendAspNetCore.Dtos.Response;

public class ApiResponseFail
{
    public int StatusCode { get; set; }
    public int IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
    public static ApiResponseFail FailResponse(string message, int statusCode = 400)
    {
        return new()
        {
            StatusCode = statusCode,
            IsSuccess = 0,
            Message = message,
        };
    }
}