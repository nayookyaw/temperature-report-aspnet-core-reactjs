public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;
    public UserService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<List<UserDto>> GetAllUserAsync()
    {
        var userList = await _userRepo.GetAllUsersAsync();
        return userList.Select(UserMapper.ToDto).ToList();
    }
}