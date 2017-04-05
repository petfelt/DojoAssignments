using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranterApplication.Models
{
    public class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }
        [Required(ErrorMessage = "Your name is required.")]
        [MinLength(2, ErrorMessage = "Your name needs to be longer than 2 letters long.")]
        public string reviewerName { get; set; }
        [Required(ErrorMessage = "A restaurant name is required.")]
        [MinLength(2, ErrorMessage = "The restaurant name needs to be longer than 2 letters long.")]

        public string restaurantName { get; set; }
        [Required(ErrorMessage = "You need to give a star rating with your review.")]
        [Range(0,5, ErrorMessage = "Your star rating must be between 1 and 5.")]
        public int stars { get; set; }
        public string review { get; set; }
        public int numHelpful { get; set; }
        public int numUnhelpful { get; set; }
        [Required(ErrorMessage = "You need to have a date of visit.")]
        [InThePast(ErrorMessage = "Please put in a valid date. No dates from the future allowed!")]
        public DateTime dateOfVisit { get; set; }
        
        public DateTime createdAt { get; set; }
        public Review()
        {
            numHelpful = 0;
            numUnhelpful = 0;
            createdAt = DateTime.Now;
        }
    }
}