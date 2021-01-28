namespace DeveloperCodingTest.Models
{
    public class Membership
    {
        public int Number { get; set; }
        public decimal AccountBalance { get; set; }
        public int PersonId { get; set; }
        public int MembershipTypeId { get; set; }
        public Person Person { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}
