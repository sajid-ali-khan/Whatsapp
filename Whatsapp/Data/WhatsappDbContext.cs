using Microsoft.EntityFrameworkCore;
using Whatsapp.Models;

namespace Whatsapp.Data
{
    public class WhatsappDbContext: DbContext
    {
        public WhatsappDbContext(DbContextOptions<WhatsappDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            
            modelBuilder.Entity<Contact>()
                .HasKey(c => c.Id);


            modelBuilder.Entity<Contact>()
                .HasMany(c => c.Messages)
                .WithOne(m => m.Contact)
                .HasForeignKey(m => m.ContactId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Message>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Message>()
                .Property(m => m.SentAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
