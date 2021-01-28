using Microsoft.EntityFrameworkCore;
using DeveloperCodingTest.Models;

namespace DeveloperCodingTest.Configuration
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MembershipType>().HasData(
                new MembershipType { Id = 1, Description = "Primary"},
                new MembershipType { Id = 2, Description = "Secondary" }
            );
           
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, ForeName = "Aaaaa", SurName = "Xxxxx", Email = "Aaaaa@Xxxxx.com" },
                new Person { Id = 2, ForeName = "Bbbbb", SurName = "Yyyyy", Email = "Bbbbb@Yyyyy.com" },
                new Person { Id = 3, ForeName = "Ccccc", SurName = "Zzzzz", Email = "Ccccc@Zzzzz.com" }
            );

            modelBuilder.Entity<Membership>().HasData(
                new Membership { Number = 111, AccountBalance = 10.45M, PersonId = 1, MembershipTypeId = 1 },
                new Membership { Number = 111, AccountBalance = 11.45M, PersonId = 1, MembershipTypeId = 2 },
                new Membership { Number = 333, AccountBalance = 12.00M, PersonId = 2, MembershipTypeId = 1 },
                new Membership { Number = 444, AccountBalance = 12.00M, PersonId = 3, MembershipTypeId = 1 }
            );
        }
    }
}
