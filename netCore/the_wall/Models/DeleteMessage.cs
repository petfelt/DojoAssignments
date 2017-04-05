using System;
using System.ComponentModel.DataAnnotations;

namespace the_wall.Models
{
    public class DeleteMessage
    {
        [Required(ErrorMessage = "Message deleted.")]
        public string Delete {get; set; }

    }

}