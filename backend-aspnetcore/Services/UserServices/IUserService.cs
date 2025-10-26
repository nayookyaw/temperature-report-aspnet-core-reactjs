namespace BackendAspNetCore.Services.UserServices;
public interface IUserService
{
    Task<Object> GetAllUserAsync();
    Task<Object> AddUserAsync(AddUserRequestBody input);
}