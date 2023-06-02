using Actividad1.Data;
using Actividad1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Regsister(UserRegister register)
        {
            if (_context.Users.Any(u=>u.Email == register.Email)) 
            {
                return BadRequest("Usuario ya existe");
            }

            var user = new User
            {
                Email = register.Email,
                password = register.password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Usuario creado");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLogin login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == login.Email);
            if (user == null)
            {
                return BadRequest("Usuario no encontrado");
            }

            if (login.password != user.password)
            {
                return BadRequest("Contrasena incorrecta");
            }

            return Ok("Usuario valido");
        }
    }
}
