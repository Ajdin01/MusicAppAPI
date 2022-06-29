using System.ComponentModel.DataAnnotations;

namespace MusicAppAPI.Models
{
    public class UserRegisterRequest //data transfer model for registering
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required, MinLength(6, ErrorMessage ="Minimum lenght is 6 characters.")]
        public string Password { get; set; } = string.Empty;
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
