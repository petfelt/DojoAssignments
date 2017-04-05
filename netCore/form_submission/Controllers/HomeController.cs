using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quoting_dojo.Models;

namespace quoting_dojo.Controllers
{
    public class HomeController : Controller
    {

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Create(string FirstName, string LastName, string Age, string EmailAddress, string Password)
        {
            User newUser = new User(){
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                EmailAddress = EmailAddress,
                Password = Password
            };
            TryValidateModel(newUser);
            if(ModelState.IsValid){
                return RedirectToAction("Success");
            } else {
                ViewBag.errors = ModelState.Values;
                return View("Index");
            }
            
        }

        [HttpGet]
        [Route("Register")]
        public IActionResult Refresh()
        {
            // Just in case users go to this page directly for some reason.
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Success")]
        public IActionResult Success(){
            return View("Register");
        }

    }
}
