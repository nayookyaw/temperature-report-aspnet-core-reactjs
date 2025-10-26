using BackendAspNetCore.Dtos.Response;

public interface IUserService
{
    Task<ApiResponse<List<UserDto>>> GetAllUserAsync();
}