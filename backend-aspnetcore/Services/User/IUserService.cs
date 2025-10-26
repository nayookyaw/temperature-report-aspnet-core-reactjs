using BackendAspNetCore.Dtos.Response;

public interface IUserService
{
    Task<Object> GetAllUserAsync();
}