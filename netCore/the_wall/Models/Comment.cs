using System;
using System.ComponentModel.DataAnnotations;

namespace the_wall.Models
{
    public class Comment
    {
        [Required(ErrorMessage = "Your comment must contain some text.")]
        [MinLengthAttribute(3, ErrorMessage = "Your comment must be at least {1} characters long.")]
        public string Post {get; set; }

        [Required(ErrorMessage = "Your comment must have a User ID.")]
        public string UserID {get; set; }

        [Required(ErrorMessage = "Your comment must have a Message ID.")]
        public string MessageID {get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Comment()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

    }

}