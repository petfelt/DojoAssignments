using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestauranterApplication.Models;
using System.Linq;

namespace RestauranterApplication.Controllers
{
    public class HomeController : Controller
    {

        private RestauranterContext _context;

        public HomeController(RestauranterContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            ViewBag.values = new List<string> { "", "", "" };
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult NewReview(string reviewerName, int stars, string restaurantName, string review, int numHelpful, int numUnhelpful, DateTime dateOfVisit)
        {
            Review newReview = new Review()
            {
                reviewerName = reviewerName,
                stars = stars,
                review = review,
                restaurantName = restaurantName,
                numHelpful = numHelpful,
                numUnhelpful = numUnhelpful,
                dateOfVisit = dateOfVisit

            };
            TryValidateModel(newReview);
            if (ModelState.IsValid)
            {
                _context.Add(newReview);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                ViewBag.values = new List<string> { reviewerName, restaurantName, review };
                return View("Index");
            }
        }

        [HttpGet]
        [Route("Reviews")]
        public IActionResult Reviews()
        {
            List<Review> AllReviews = _context.Review.OrderByDescending(o=>o.dateOfVisit).ToList ();
            ViewBag.AllReviews = AllReviews;
            return View("Reviews");
        }
    }
}
