using System.ComponentModel.DataAnnotations;

namespace Blazor_Tim1.Models
{
    public class DisplayPersonModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "First Name is too long.")]
        [MinLength(1, ErrorMessage = "First Name is too short.")]
        public string FirstName { set; get; }
        [Required]
        [StringLength(50, ErrorMessage = "Last Name is too long.")]
        [MinLength(3, ErrorMessage = "Last Name is too short.")]
        public string LastName { set; get; }
        [Required]
        [EmailAddress]
        public string EmailAddress { set; get; }
    }
}
