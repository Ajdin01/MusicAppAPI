using System.ComponentModel.DataAnnotations;

namespace MusicAppAPI.Models
{
    public class UserLoginRequest //data transfer model for logging in
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
