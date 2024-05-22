using Microsoft.EntityFrameworkCore;
using handydandy.Models;

namespace handydandy.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Users> User { get; set; }
        public DbSet<Cases> Case { get; set; }
        public DbSet<Tradesmans> Tradesman { get; set; }
        public DbSet<Offers> Offer { get; set; }
        public DbSet<Chats> Chats { get; set; }
        public DbSet<Messages> Message { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API Config
        }
    }
}


