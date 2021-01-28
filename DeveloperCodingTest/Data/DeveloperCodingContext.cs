using DeveloperCodingTest.Models;
using Microsoft.EntityFrameworkCore;
using DeveloperCodingTest.Configuration;

namespace DeveloperCodingTest.Data
{
    public class DeveloperCodingContext : DbContext
    {
        public DeveloperCodingContext(DbContextOptions<DeveloperCodingContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Membership>(entity =>
            {
                entity.HasKey(m => new { m.PersonId, m.MembershipTypeId });
               // entity.HasIndex(e => e.Number).IsUnique();
                entity.Property(p => p.AccountBalance).HasPrecision(9, 4);
            });

            modelBuilder.Seed();
            //modelBuilder.Entity<Membership>()
            //    .HasKey(m => new { m.PersonId, m.MembershipTypeId });
            //modelBuilder.Entity<Membership>()
            //    .Property(p => p.AccountBalance)
            //    .HasPrecision(9, 4);
        }
        
        DbSet<Person> People { get; set; }
        DbSet<Membership> Memberships { get; set; }
        DbSet<Membership> MembershipTypes { get; set; }


    }
}
