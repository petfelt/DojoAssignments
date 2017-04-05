using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts.Controllers
{
    public class HomeController : Controller
    {
        private BankAccountsContext _context;

        public HomeController(BankAccountsContext context)
        {
            _context = context;
        }


        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            ViewBag.values = new List<string> { "", "", "", "", "" };
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailAddress = model.EmailAddress,
                    Password = model.Password,
                };
                _context.Add(newUser);
                _context.SaveChanges();
                // Grab user ID here so we can add it to the redirect link.
                User MyUser = _context.User.Where(user => user.EmailAddress == model.EmailAddress)
                    .SingleOrDefault();
                if (MyUser != null)
                {
                    HttpContext.Session.SetString("MyEmail", model.EmailAddress);
                    int tempID = MyUser.UserId;
                    return RedirectToAction("Account", new { myID = tempID });
                }
            }
            ViewBag.errors = ModelState.Values;
            ViewBag.values = new List<string> { model.FirstName, model.LastName, model.EmailAddress, model.Password, model.PasswordConfirmation };
            return View("Index");
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult LoginIndex()
        {
            ViewBag.errors = new List<string>();
            ViewBag.values = new List<string> { "", "", "", };
            return View("Login");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User MyUser = _context.User.Where(user => user.EmailAddress == model.EmailAddress)
                    .SingleOrDefault();
                // If you grabbed a user...
                if (MyUser != null)
                {
                    HttpContext.Session.SetString("MyEmail", model.EmailAddress);
                    int tempID = MyUser.UserId;
                    return RedirectToAction("Account", new { myID = tempID });
                }
            }
            ViewBag.errors = ModelState.Values;
            ViewBag.values = new List<string> { model.EmailAddress, model.Password, "Your email/password combination does not match any of our accounts. Make a new account or try again." };
            return View("Login");
        }

        [HttpGet]
        [Route("Account/{myID}")]
        public IActionResult Account(int myID)
        {
            User MyUser = _context.User.Where(u => u.UserId == myID)
                    .Include(user => user.Transactions)
                    .SingleOrDefault();
            if (MyUser != null)
            {
                if (HttpContext.Session.GetString("MyEmail") == MyUser.EmailAddress)
                {
                    ViewBag.errors = new List<string>();
                    ViewBag.values = new List<string> { "" };
                    MyUser.Transactions = MyUser.Transactions.OrderByDescending(o => o.CreatedAt).ToList();
                    ViewBag.MyUser = MyUser;
                    return View("Account");
                }
            }
            ViewBag.errors = new List<string>();
            ViewBag.values = new List<string> { HttpContext.Session.GetString("MyEmail"), "", "You can only view your account page." };
            return View("Login");
        }

        [HttpPost]
        [Route("Account/{myID}")]
        public IActionResult NewTransaction(int myID, CreateTransactionModel model)
        {
            ViewBag.errors = new List<string>();
            User MyUser = _context.User.Where(u => u.UserId == myID)
                    .Include(user => user.Transactions)
                    .SingleOrDefault();

            if (MyUser != null)
            {
                if (HttpContext.Session.GetString("MyEmail") == MyUser.EmailAddress)
                {
                    if (ModelState.IsValid)
                    {
                        Transaction newTransaction = new Transaction()
                        {
                            Amount = model.Amount,
                            UserId = MyUser.UserId,
                            User = MyUser
                        };
                        int temp = newTransaction.User.Balance;
                        if (temp + model.Amount >= 0)
                        {
                            newTransaction.User.Balance += model.Amount;
                            _context.Add(newTransaction);
                            _context.SaveChanges();
                            ViewBag.values = new List<string> { "" };
                        }
                        else
                        {
                            ViewBag.values = new List<string> { "You cannot withdraw more money than you have." };
                        }
                    }
                    else
                    {
                        ViewBag.values = new List<string> { "That is not a valid amount to deposit or withdraw." };
                    }
                    MyUser.Transactions = MyUser.Transactions.OrderByDescending(o => o.CreatedAt).ToList();
                    ViewBag.MyUser = MyUser;
                    return View("Account");
                }
            }
            ViewBag.values = new List<string> { HttpContext.Session.GetString("MyEmail"), "", "You can only view your account page." };
            return View("Login");
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
