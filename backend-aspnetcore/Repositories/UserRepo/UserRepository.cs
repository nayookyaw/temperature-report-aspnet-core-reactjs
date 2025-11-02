using Microsoft.EntityFrameworkCore;
using BackendAspNetCore.Data;
using BackendAspNetCore.Models.User;

namespace BackendAspNetCore.Repositories.UserRepo;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;
    public UserRepository(AppDbContext db) => _db = db;
    public async Task<List<User>> GetAllUsersAsync() =>
        await _db.Users.AsNoTracking().OrderBy(u => u.Username).ToListAsync();

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _db.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
    }
    public async Task<User> CreateUserAsync(User newUser)
    {
        _db.Users.Add(newUser);
        await _db.SaveChangesAsync();
        return newUser;
    }
}