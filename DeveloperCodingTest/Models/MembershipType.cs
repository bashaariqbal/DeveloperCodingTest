using System.Collections.Generic;

namespace DeveloperCodingTest.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Membership> Memberships { get; set; }
    }
}
