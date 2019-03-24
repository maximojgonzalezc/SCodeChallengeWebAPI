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
                e.OwnsOne(p => p.Address).Property(c => c.AddressLine1).HasColumnName("AddressLine1");
                e.OwnsOne(p => p.Address).Property(c => c.City).HasColumnName("City");
                e.OwnsOne(p => p.Address).Property(c => c.State).HasColumnName("State");

                e.OwnsOne(p => p.ContactPhone).Property(c => c.PersonalPhone).HasColumnName("PersonalPhone");
                e.OwnsOne(p => p.ContactPhone).Property(c => c.WorkPhone).HasColumnName("WorkPhone");

                e.HasAlternateKey(c => c.Email);
            });
        }
    }

}
