using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.Repositories.UserRepo;
using Backend.RequestBody.UserRequestBody;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repoUser;

        public UsersController(IUserRepository repoUser)
        {
            _repoUser = repoUser;
        }

        // GET: /api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> List(
            [FromQuery] string? search,
            [FromQuery] string? sort = "createdAt",
            [FromQuery] string dir = "desc"
            )
        {
            int page = 1;
            int pageSize = 50;
            
            var (userList, totalUser) = await _repoUser.GetUserList(search,sort,dir,page, pageSize);
            return Ok(new { userList, totalUser});
        }

        // GET: /api/users/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> Get(int userId)
        {
            // var user = await _db.Users.FindAsync(id);
            var user = await _repoUser.GetUserById(userId);
            return user is null ? NotFound() : Ok(user);
        }

        // POST: /api/users
        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] CreateUserRequestBody input)
        {
            if (string.IsNullOrWhiteSpace(input.Name) || string.IsNullOrWhiteSpace(input.Email))
                return BadRequest("Name and Email are required.");

            var inputUser = new User
            {
                Name = input.Name,
                Email = input.Email,
                IsActive = input.IsActive,
                CreatedAt = DateTime.UtcNow
            };

            var user = await _repoUser.CreateUser(inputUser);
            return user is null ? NotFound() : Ok(user);
        }

        // PUT: /api/users/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int userId, [FromBody] User input)
        {
            var existingUser = await _repoUser.GetUserById(userId);
            if (existingUser is null) return NotFound();

            existingUser.Name = input.Name;
            existingUser.Email = input.Email;
            existingUser.IsActive = input.IsActive;

            await _repoUser.UpdateUser(existingUser);
            return NoContent();
        }

        // DELETE: /api/users/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var existingUser = await _repoUser.GetUserById(userId);
            if (existingUser is null) return NotFound();
            await _repoUser.DeleteUser(existingUser);
            return NoContent();
        }
    }
}
