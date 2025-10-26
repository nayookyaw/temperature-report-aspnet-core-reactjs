using BackendAspNetCore.Dtos.Response;
using BackendAspNetCore.Models.User;
using BackendAspNetCore.Mappers;
using BackendAspNetCore.Repositories.UserRepo;

namespace BackendAspNetCore.Services.UserServices;

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
        List<UserDto> userDtoList = userList.Select(u => UserMapper.ToDto(u)).ToList();

        if (userDtoList.Count == 0)
        {
            return ApiResponseFail.FailResponse("No user is found", 400);
        }

        return ApiResponse<List<UserDto>>.SuccessResponse(userDtoList, "Users has been retrieved", 200);
    }

    public async Task<Object> AddUserAsync(AddUserRequestBody input)
    {
        User? existUser = await _userRepo.GetUserByEmail(input.Email);
        if (existUser == null)
        {
            return ApiResponseFail.FailResponse("No user is found", 400);
        }

        UserDto userDto = UserMapper.ToDto(existUser);
        return ApiResponse<UserDto>.SuccessResponse(userDto, "New user has been added", 200);
    }
}