using System.ComponentModel.DataAnnotations;

namespace Section6Forms.Models
{
    public class PersonModel
    {
        [Required]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Invalid First Name Length.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "Invalid Last Name Length.")]
        public string LastName { get; set; }

        // Added for Validation

        [Range(0, 125, ErrorMessage = "You Need to enter a valid age.")]
        public int Age { get; set; }

        // false not allowed
        [Range(typeof(bool), "true", "true", ErrorMessage = "You need to give consent to continue")]
        public bool GaveConsent { get; set; }
    }
}
