using System.ComponentModel.DataAnnotations;
namespace ECommerce.Models
{
    public class CreateCustomer : BaseEntity
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "A name is required.")]
        [MinLength(2, ErrorMessage = "The name must be more than one character long.")]
        [RegularExpression(@"^[a-zA-Z ,.'-]+$", ErrorMessage = "The name cannot contain numbers or most symbols.")]
        public string CustomerName { get; set; }
    }
}