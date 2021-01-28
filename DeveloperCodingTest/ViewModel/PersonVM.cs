using System.ComponentModel.DataAnnotations;

namespace DeveloperCodingTest.ViewModel
{
    public class PersonVM
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
    }
}
