using Actividad1.Model;
using Microsoft.EntityFrameworkCore;

namespace Actividad1.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-B3T4PJF;Initial Catalog=Actividad1;Integrated Security=True;trustservercertificate=true");
        }
        public DbSet<User> Users { get; set; }
    }
}
