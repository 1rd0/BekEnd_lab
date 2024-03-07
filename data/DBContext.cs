using asp_empty.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace asp_empty.data
{
    public class DBcontext : DbContext
    {
        public DbSet<User> users { get; set; }

        public string DataBaseconnection = "Host=localhost; Database=DBfor14lab ; Username=postgres; Password=admin"
              ;

        public DBcontext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(DataBaseconnection);
        }
    }
}
