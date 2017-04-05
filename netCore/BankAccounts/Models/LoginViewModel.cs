using System.ComponentModel.DataAnnotations;
namespace BankAccounts.Models
{
    public class LoginViewModel : BaseEntity
    {
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "You must put in a valid email address.")]
        public string EmailAddress { get; set; }
 
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Your password must be longer than 8 characters.")]
        [DataType(DataType.Password, ErrorMessage = "Password must be a password.")]
        public string Password { get; set; }
    }
}