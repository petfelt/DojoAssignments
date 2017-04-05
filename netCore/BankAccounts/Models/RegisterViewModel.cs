using System.ComponentModel.DataAnnotations;
namespace BankAccounts.Models
{
    public class RegisterViewModel : BaseEntity
    {
        [Required(ErrorMessage = "First name is required.")]
        [MinLength(2, ErrorMessage = "Your first name must be more than one character long.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Your last name can only contain letters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MinLength(2, ErrorMessage = "Your last name must be more than one character long.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Your last name can only contain letters.")]
        public string LastName { get; set; }
 
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "You must put in a valid email address.")]
        public string EmailAddress { get; set; }
 
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Your password must be longer than 8 characters.")]
        [DataType(DataType.Password, ErrorMessage = "Password must be a password.")]
        public string Password { get; set; }
 
        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        public string PasswordConfirmation { get; set; }
    }
}