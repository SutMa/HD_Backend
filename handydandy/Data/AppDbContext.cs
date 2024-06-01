namespace handydandy.Data
{
    using Microsoft.EntityFrameworkCore;
    using handydandy.Models;
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Tradesman> Tradesmans { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Users 
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);
            modelBuilder.Entity<User>()
                .Property(u => u.UserId)
                .ValueGeneratedOnAdd();
               

            //Tradesmans
            modelBuilder.Entity<Tradesman>()
                .HasKey(t => t.TradesmanId);
            modelBuilder.Entity<Tradesman>()
                .Property(t => t.TradesmanId)
                .ValueGeneratedOnAdd();

            //Cases
            modelBuilder.Entity<Case>()
                .HasKey(c => c.CaseId);
            modelBuilder.Entity<Case>()
                .Property(c => c.CaseId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Case>()
              .HasOne(c => c.User)
              .WithMany(u => u.Cases)
              .HasForeignKey(c => c.UserId);

            //Offers 
            modelBuilder.Entity<Offer>()
                .HasKey(o => o.OfferId);
            modelBuilder.Entity<Offer>()
                .Property(o => o.OfferId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Offer>()
                .HasOne(o => o.Case)
                .WithMany(c => c.Offers)
                .HasForeignKey(o => o.CaseId);

            modelBuilder.Entity<Offer>()
                .HasOne(o => o.Tradesman)
                .WithMany(t => t.Offers)
                .HasForeignKey(o => o.TradesmanId);

            //Chats
            modelBuilder.Entity<Chat>()
                .HasKey(ch => ch.ChatId);
            modelBuilder.Entity<Chat>()
                .Property(ch => ch.ChatId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Chat>()
                .HasOne(ch => ch.Case)
                .WithOne(c => c.Chat)
                .HasForeignKey<Chat>(ch => ch.CaseId);

            //Messages
            modelBuilder.Entity<Message>()
                .HasKey(m => m.MessageId);
            modelBuilder.Entity<Message>()
                .Property(m => m.MessageId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Chat)
                .WithMany(ch => ch.Messages)
                .HasForeignKey(m => m.ChatId);
        }
    }
}


