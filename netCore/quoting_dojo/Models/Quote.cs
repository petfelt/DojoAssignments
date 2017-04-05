using System;
using System.ComponentModel.DataAnnotations;

namespace quoting_dojo.Models
{
    public class Quote
    {
        [Required]
        [MinLengthAttribute(2)]
        public string Name { get; set; }

        [Required]
        [MinLengthAttribute(4)]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public Quote()
        {
            CreatedAt = DateTime.Now;
        }

    }

}