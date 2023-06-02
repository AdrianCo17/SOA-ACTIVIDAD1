using System.ComponentModel.DataAnnotations;

namespace Actividad1.Model
{
    public class UserLogin
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;

    }
}
