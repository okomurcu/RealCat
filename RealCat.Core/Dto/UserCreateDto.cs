using System.ComponentModel.DataAnnotations;

namespace RealCat.Core.Dto
{
    public class UserCreateDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters.")]
        public string Username { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 3, ErrorMessage = "Password must be between 4 and 32 characters.")]
        public string Password { get; set; }
    }
}
