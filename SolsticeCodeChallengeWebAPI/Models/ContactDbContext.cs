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
                e.HasOne(x => x.ContactPhone)
                    .WithOne(y => y.Contact)
                    .HasForeignKey<ContactPhone>(z => z.ContactPhonesContactForeignKey);

                e.HasOne(x => x.Address)
                    .WithOne(y => y.Contact)
                    .HasForeignKey<Address>(z => z.AddresssContactForeignKey);
            });
        }
    }

}
