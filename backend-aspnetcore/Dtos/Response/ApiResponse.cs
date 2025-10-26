
namespace BackendAspNetCore.Dtos.Response;

public class ApiResponse<T>
{
    public int StatusCode { get; set; }
    public int IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    // Factory helpers
    public static ApiResponse<T> SuccessResponse(T data, string message = "Success", int statusCode = 200)
    {
        return new ApiResponse<T>
        {
            StatusCode = statusCode,
            IsSuccess = 1,
            Message = message,
            Data = data,
        };
    }
}