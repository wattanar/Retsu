using System.ComponentModel.DataAnnotations;

namespace Web.Modules.User.Dto
{
    public class UserLoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}