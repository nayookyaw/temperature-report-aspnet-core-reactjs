public interface IUserService
{
    Task<List<UserDto>> GetAllUserAsync();
}