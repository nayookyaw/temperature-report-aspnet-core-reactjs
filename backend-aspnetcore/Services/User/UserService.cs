using BackendAspNetCore.Dtos.Response;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;
    public UserService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<ApiResponse<List<UserDto>>> GetAllUserAsync()
    {
        var userList = await _userRepo.GetAllUsersAsync();
        var userDtoList = userList.Select(UserMapper.ToDto).ToList();

        return ApiResponse<List<UserDto>>.SuccessResponse(userDtoList, "Users has been retrieved", 200);
    }
}