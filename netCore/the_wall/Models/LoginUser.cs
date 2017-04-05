using System;
using System.ComponentModel.DataAnnotations;

namespace the_wall.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Your email address is required.")]
        [EmailAddressAttribute(ErrorMessage = "You need to enter a valid email address.")]
        public string EmailAddress {get; set; }

        public string ConfirmEmailAddress {get; set; }

        [Required(ErrorMessage = "A password is required.")]
        [MinLengthAttribute(8, ErrorMessage = "Your password must be at least {1} characters long.")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "The email address / password you entered do not match what we have in our database.")]
        public string ConfirmPassword {get; set; }
    }

}