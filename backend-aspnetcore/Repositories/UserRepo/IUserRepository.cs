
using Backend.Models;

namespace Backend.Repositories.UserRepo
{
    public interface IUserRepository
    {
        public Task<(IReadOnlyList<User> users, int userTotal)> GetUserList(
            string? search, string? sort, string dir, int page, int pageSize
        );
        public Task<User?> GetUserById(int userId);
        public Task<User> CreateUser(User newUser);
        public Task<bool> UpdateUser(User updateUser);
        public Task<bool> DeleteUser(User deleteUser);
    }
}