namespace BackendAspNetCore.Services.UserServices;
public interface IUserService
{
    Task<ApiResponse> GetAllUserAsync();
    Task<ApiResponse> AddUserAsync(AddUserRequestBody input);
}