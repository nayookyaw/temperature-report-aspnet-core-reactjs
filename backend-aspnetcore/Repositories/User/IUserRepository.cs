public interface IUserRepository
{
    // Task<User> GetUserByIdAsync(Guid id);
    Task<List<User>> GetAllUsersAsync();
    // Task AddUserAsync(User user);
    // Task UpdateUserAsync(User user);
    // Task DeleteUserAsync(Guid id);
}