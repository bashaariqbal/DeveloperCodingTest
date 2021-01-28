using System.ComponentModel.DataAnnotations;

namespace DeveloperCodingTest.ViewModel
{
    public class MembershipVM
    {
        public int Number { get; set; }
       
        [Display(Name = "Balance")]
        public decimal AccountBalance { get; set; }
        public string MembershipType { get; set; }
        public string PersonName { get; set; }
        public int PersonId { get; set; }
        public int MembershipTypeId { get; set; }

    }
}
