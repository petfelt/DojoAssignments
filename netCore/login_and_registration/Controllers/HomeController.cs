using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quoting_dojo.Models;

namespace quoting_dojo.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            ViewBag.values = new List<string> {"", "", "", "", ""};
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Create(string FirstName, string LastName, string EmailAddress, string Password, string ConfirmPassword)
        {
            if(EmailAddress == null){
                EmailAddress = "abcd_nullify";
                Console.WriteLine("YASDFQWYEFOQWJNEDFJQNWDLFJQNWDLF");
            }
            String ConfirmEmailAddress = EmailAddress;
            List<Dictionary<string, object>> ThisUser = _dbConnector.Query("SELECT * FROM users WHERE EmailAddress LIKE '%"+EmailAddress+"%'");
            foreach(Dictionary<string, object> dict in ThisUser){
                // If the email is found in the database, make it impossible to match.
                ConfirmEmailAddress = "false";
            }
            Console.WriteLine("X###########################XXXXXXX###$@!#$%!@#$!@#%!@#$!@#%!@#$");
            Console.WriteLine(ConfirmEmailAddress);
            Console.WriteLine(EmailAddress);
            User newUser = new User()
            {
                FirstName = FirstName,
                LastName = LastName,
                EmailAddress = EmailAddress,
                Password = Password,
                ConfirmPassword = ConfirmPassword,
                ConfirmEmailAddress = ConfirmEmailAddress
            };
            TryValidateModel(newUser);
            if (ModelState.IsValid)
            {
                string QueryString = $"INSERT INTO users (FirstName, LastName, EmailAddress, Password, createdAt) VALUES ('{newUser.FirstName}','{newUser.LastName}','{newUser.EmailAddress}','{newUser.Password}',NOW())";
                _dbConnector.Execute(QueryString);
                return RedirectToAction("Success");
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                if(EmailAddress == "abcd_nullify"){
                    EmailAddress = "";
                }
                ViewBag.values = new List<string> {FirstName, LastName, EmailAddress, Password, ConfirmPassword};
                return View("Index");
            }

        }

        [HttpPost]
        [Route("Login")]

        public IActionResult Login(string EmailAddress, string Password)
        {
            List<Dictionary<string, object>> ThisUser = _dbConnector.Query("SELECT * FROM users WHERE EmailAddress LIKE '%"+EmailAddress+"%'");
            string ConfirmEmailAddress = "";
            string ConfirmPassword = "";
            // Grab the potential email & password from database.
            foreach(Dictionary<string, object> dict in ThisUser){
                foreach(object list in dict){
                    string str = list.ToString();
                    if(str[1] == 'E'){ // If it's an email.
                        ConfirmEmailAddress = str.Substring(15, str.Length-16);
                    }
                    if(str[1] == 'P'){ // If it's a password.
                        ConfirmPassword = str.Substring(11, str.Length-12);
                    }
                }
            }
            // Put in confirmations vs user inputs into login model and try it.
            LoginUser tempUser = new LoginUser()
            {
                EmailAddress = EmailAddress,
                ConfirmEmailAddress = ConfirmEmailAddress,
                Password = Password,
                ConfirmPassword = ConfirmPassword
            };
            TryValidateModel(tempUser);
            if (ModelState.IsValid)
            {
                // Successfully logged in.
                return RedirectToAction("Success");
            }
            else
            {
                // Login failed.
                ViewBag.errors = ModelState.Values;
                ViewBag.values = new List<string> {"", "", EmailAddress, Password, ""};
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
        public IActionResult Success()
        {
            return View("Register");
        }

    }
}
