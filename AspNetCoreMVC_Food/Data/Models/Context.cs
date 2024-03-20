using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVC_Food.Data.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= (localdb)\\Mehmet; Database=OnlineFoodOrder; Integrated Security=True;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
