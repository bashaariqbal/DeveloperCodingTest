using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeveloperCodingTest.Models
{
    public class Person
    {
        public int Id { get; set; }
      
        [Required]
        [MaxLength(250)]
        [Display(Name = "First Name")]
        public string ForeName { get; set; }
        
        [Required]
        [MaxLength(250)]
        [Display(Name = "Last Name")]
        public string SurName { get; set; }

        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }
        public List<Membership> Memberships { get; set; } = new List<Membership>();
    }
}
