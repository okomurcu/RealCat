using System.ComponentModel.DataAnnotations;

namespace RealCat.Core.ViewModel
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
