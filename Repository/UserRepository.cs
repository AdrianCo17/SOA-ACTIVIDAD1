using Actividad1.Model;
using Microsoft.EntityFrameworkCore;

namespace Actividad1.Repository
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<User> ObtenerLista()
        {
            List<User> lista = new List<User>();
            lista = _context.Users.ToList();


            return lista;

        }
    }
}
