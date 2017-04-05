using System;
using System.ComponentModel.DataAnnotations;

namespace quoting_dojo.Models
{
    public class User
    {
        [Required(ErrorMessage = "Your first name is required.")]
        [MinLengthAttribute(4, ErrorMessage = "Your first name must be at least {1} characters long.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Your last name is required.")]
        [MinLengthAttribute(4, ErrorMessage = "Your last name must be at least {1} characters long.")]
        public string LastName {get; set; }

        [Required(ErrorMessage = "Your age is required.")]
        [RangeAttribute(1,123, ErrorMessage = "You need to be between {1} and {2} years old to register. (AkA alive and able to type!)")]
        public string Age {get; set; }

        [Required(ErrorMessage = "Your email address is required.")]
        [EmailAddressAttribute(ErrorMessage = "You need to enter a valid email address.")]
        public string EmailAddress {get; set; }

        [Required(ErrorMessage = "A password is required.")]
        [MinLengthAttribute(8, ErrorMessage = "Your password must be at least {1} characters long.")]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }

        public User()
        {
            CreatedAt = DateTime.Now;
        }

    }

}