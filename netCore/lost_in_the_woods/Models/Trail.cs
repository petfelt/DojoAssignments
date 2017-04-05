using System;
using System.ComponentModel.DataAnnotations;

namespace the_wall.Models
{
    public abstract class BaseEntity {}
    public class Trail : BaseEntity
    {
        [Key]
        public long Id { get; set; }
 
        [Required(ErrorMessage = "Your Trail needs a name.")]
        [MinLength(2,ErrorMessage = "Your Trail's name needs to be longer than {1} characters long.")]
        public string Name { get; set; }
 
        [Required(ErrorMessage = "Your Trail needs a description.")]
        [MinLength(10, ErrorMessage = "Your Trail's description needs to be longer than {1} characters long.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You need to give your Trail a length.")]
        [RangeAttribute(0.001,1000.0, ErrorMessage = "Your Trail length must be between {1} & {2} Miles long.")]
        public string TrailLength { get; set; }

        [Required(ErrorMessage = "You need to give your Trail an elevation change.")]
        [RangeAttribute(0,100000, ErrorMessage = "Your Trail's elevation change must be between {1} & {2} feet.")]
        public string ElevationChange { get; set; }

        [Required(ErrorMessage = "Your Trail needs a longitude.")]
        [RegularExpression(@"^(\+|-)?(?:180(?:(?:\.0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\.[0-9]{1,6})?))$", ErrorMessage = "Your longitude must be a valid longitude. (Number between -180.0 & 180.0.)")]
        public string Longitude { get; set; }

        [Required(ErrorMessage = "Your Trail needs a latitude.")]
        [RegularExpression(@"^(\+|-)?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,6})?))$", ErrorMessage = "Your latitude must be a valid latitude. (Number between -90.0 & 90.0.)")]
        public string Latitude { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Trail()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

    }

}