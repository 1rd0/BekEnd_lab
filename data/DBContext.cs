using asp_empty.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace asp_empty.data
{
    public class DBcontext : DbContext
    {

        public DbSet<User> Users { get; set; }

 

        public DBcontext() {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql();
        }
    }
}
