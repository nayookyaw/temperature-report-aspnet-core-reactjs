using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.UserRepo
{
    public class EfUserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public EfUserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<(IReadOnlyList<User> users, int userTotal)> GetUserList(
            string? search, string? sort, string dir, int page, int pageSize
        )
        {
            IQueryable<User> query = _db.Users.AsNoTracking();

            // filter
            if (!String.IsNullOrWhiteSpace(search))
            {
                var keywordStr = search.Trim().ToLower();
                query = query.Where(u =>
                    u.Name.ToLower().Contains(keywordStr) ||
                    u.Email.ToLower().Contains(keywordStr)
                );
            }

            // pagination
            page = page <= 0 ? 1 : page;
            pageSize = pageSize <= 0 ? 50 : Math.Min(pageSize, 500);
            var totalUser = await query.CountAsync(CancellationToken.None);
            var userList = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(CancellationToken.None);
            return (userList, totalUser);
        }

        public Task<User?> GetUserById(int userId)
        {
            return _db.Users.AsNoTracking().FirstOrDefaultAsync(
                u => u.Id == userId, CancellationToken.None
            );
        }

        public async Task<User> CreateUser(User newUser)
        {
            _db.Users.Add(newUser);
            await _db.SaveChangesAsync(CancellationToken.None);
            return newUser;
        }

        public async Task<bool> UpdateUser(User updateUser)
        {
            var existUser = await _db.Users.AnyAsync(u => u.Id == updateUser.Id, CancellationToken.None);
            if (!existUser) return false;

            _db.Users.Update(updateUser);
            await _db.SaveChangesAsync(CancellationToken.None);
            return true;
        }

        public async Task<bool> DeleteUser(User deleteUser)
        {
            var existUser = await _db.Users.AnyAsync(u => u.Id == deleteUser.Id, CancellationToken.None);
            if (!existUser) return false;

            _db.Users.Remove(deleteUser);
            await _db.SaveChangesAsync(CancellationToken.None);
            return true;
        }

    }
}