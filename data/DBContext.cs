using asp_empty.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace asp_empty.data
{
    public class DBcontext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public string DataBaseConnection = "Host = localhost;Database = postgres;Username = postgres;password = admin";
 

        public DBcontext() {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(DataBaseConnection);
        }
    }
}
