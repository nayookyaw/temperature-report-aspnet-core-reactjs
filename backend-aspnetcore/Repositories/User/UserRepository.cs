using Microsoft.EntityFrameworkCore;
using BackendAspNetCore.Data;
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;
    public UserRepository(AppDbContext db) => _db = db;
    public async Task<List<User>> GetAllUsersAsync() =>
        await _db.Users.AsNoTracking().OrderBy(u => u.Username).ToListAsync();
}