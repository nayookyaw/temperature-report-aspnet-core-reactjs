using BackendAspNetCore.Dtos.Response;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;
    public UserService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<Object> GetAllUserAsync()
    {
        var userList = await _userRepo.GetAllUsersAsync();
        var userDtoList = userList.Select(UserMapper.ToDto).ToList();

        if (userDtoList.Count == 0)
        {
            return ApiResponseFail.FailResponse("No user is found", 400);
        }

        return ApiResponse<List<UserDto>>.SuccessResponse(userDtoList, "Users has been retrieved", 200);
    }
}