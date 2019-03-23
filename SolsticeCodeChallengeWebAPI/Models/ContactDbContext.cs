using Microsoft.EntityFrameworkCore;

namespace SolsticeCodeChallengeWebAPI.Models
{
    public class ContactDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactPhone> ContactPhones { get; set; }
        public DbSet<Address> ContactAddress { get; set; }

        public ContactDbContext(DbContextOptions<ContactDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(e =>
            {
                e.OwnsOne(p => p.Address);
                e.OwnsOne(p => p.ContactPhone);
            });
        }
    }

}
