using System.ComponentModel.DataAnnotations;

namespace RealCat.Core.Model
{
    public class User
    {
        [Key]
        public Guid GuidId { get; set; }
        
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
