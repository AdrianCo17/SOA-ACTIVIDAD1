using System.ComponentModel.DataAnnotations;

namespace Actividad1.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;


    }
}
