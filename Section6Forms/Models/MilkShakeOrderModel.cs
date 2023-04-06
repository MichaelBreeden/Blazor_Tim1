using System.ComponentModel.DataAnnotations;

namespace Section6Forms.Models
{
    public class MilkShakeOrderModel
    {
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Invalid Name Length.")]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid Type Length.")]
        public string Type { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid Size Length.")]
        public string Size { get; set; }

        [Range(1, 10, ErrorMessage = "Choose a quantity between 1 and 10.")]
        public int Quantity { get; set; }

        [Range(typeof(bool), "true", "false", ErrorMessage = "You need to choose whipped cream or not.")]
        public bool WhippedCream { get; set; }
    }
}
