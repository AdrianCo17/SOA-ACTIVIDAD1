using System.ComponentModel.DataAnnotations;

namespace Actividad1.Model
{
    public class UserRegister
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
        [Required, Compare("password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    } 
}
