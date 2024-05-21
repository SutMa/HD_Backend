using Microsoft.EntityFrameworkCore;
using handydandy.Models;

namespace handydandy.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Users> User { get; set; }
        public DbSet<Cases> Case { get; set; }
        public DbSet<Tradesmans> Tradesman { get; set; }
    }
}


