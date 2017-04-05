using System;
using System.ComponentModel.DataAnnotations;

namespace the_wall.Models
{
    public class User
    {
        [Required(ErrorMessage = "Your first name is required.")]
        [MinLengthAttribute(2, ErrorMessage = "Your first name must be at least {1} characters long.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Your first name can only contain letters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Your last name is required.")]
        [MinLengthAttribute(2, ErrorMessage = "Your last name must be at least {1} characters long.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Your last name can only contain letters.")]
        public string LastName {get; set; }

        [Required(ErrorMessage = "Your email address is required.")]
        [EmailAddressAttribute(ErrorMessage = "You need to enter a valid email address.")]
        public string EmailAddress {get; set; }

        [Required(ErrorMessage = "A password is required.")]
        [MinLengthAttribute(8, ErrorMessage = "Your password must be at least {1} characters long.")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Your passwords do not match.")]
        public string ConfirmPassword {get; set; }

        [Compare(nameof(EmailAddress), ErrorMessage = "Sorry, this email address is not useable or is already taken. Use a different one.")]
        public string ConfirmEmailAddress {get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

    }

}