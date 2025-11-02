
using BackendAspNetCore.Models.User;

namespace BackendAspNetCore.Repositories.UserRepo;
public interface IUserRepository
{
    Task<User?> GetUserById(Guid id);
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserByEmail(string email);
    Task<User> CreateUserAsync(User newUser);
    Task<User> UpdateUserAsync(User user);
    // Task UpdateUserAsync(User user);
    // Task DeleteUserAsync(Guid id);
}