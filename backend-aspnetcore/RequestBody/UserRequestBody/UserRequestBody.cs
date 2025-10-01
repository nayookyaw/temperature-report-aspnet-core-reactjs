
using System.ComponentModel.DataAnnotations;

namespace Backend.RequestBody.UserRequestBody
{
    public class CreateUserRequestBody
    {
        [Required, StringLength(50, MinimumLength = 0)]
        public string Name { get; set; } = String.Empty;

        [Required, StringLength(50, MinimumLength = 0)]
        public string Email { get; set; } = String.Empty;
        public bool IsActive { get; set; } = true;
    }
}