using System;
using System.ComponentModel.DataAnnotations;

namespace the_wall.Models
{
    public class Message
    {
        [Required(ErrorMessage = "Your message must contain some text.")]
        [MinLengthAttribute(5, ErrorMessage = "Your message must be at least {1} characters long.")]
        public string Post {get; set; }

        [Required(ErrorMessage = "Your message must have a User ID.")]
        public string UserID {get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Message()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

    }

}