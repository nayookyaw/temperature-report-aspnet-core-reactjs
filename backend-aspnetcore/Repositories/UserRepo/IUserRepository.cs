
using BackendAspNetCore.Models.User;

namespace BackendAspNetCore.Repositories.UserRepo;
public interface IUserRepository
{
    // Task<User> GetUserByIdAsync(Guid id);
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserByEmail(string email);
    // Task AddUserAsync(User user);
    // Task UpdateUserAsync(User user);
    // Task DeleteUserAsync(Guid id);
}