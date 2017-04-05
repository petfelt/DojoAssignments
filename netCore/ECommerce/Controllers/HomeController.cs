using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {

        private ECommerceContext _context;

        public HomeController(ECommerceContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            ViewBag.values = new List<string> { "", "" };
            return View();
        }






        [HttpGet]
        [Route("Products")]
        public IActionResult Products()
        {
            ViewBag.errors = new List<string>();
            ViewBag.values = new List<string> { "", "" };
            return View();
        }






        [HttpGet]
        [Route("Orders")]
        public IActionResult Orders()
        {
            ViewBag.errors = new List<string>();
            ViewBag.values = new List<string> { "", "" };
            return View();
        }







        [HttpGet]
        [Route("Customers")]
        public IActionResult Customers()
        {
            ViewBag.errors = new List<string>();
            ViewBag.values = new List<string> { "", "" };
            List<Customer> AllCustomers = _context.Customer.OrderByDescending(o => o.CreatedAt).ToList();
            ViewBag.allcustomers = AllCustomers;
            return View();
        }

        // Create a new customer route
        [HttpPost]
        [Route("Customers")]
        public IActionResult CreateCustomer(CreateCustomer model)
        {
            ViewBag.errors = new List<string>();
            ViewBag.values = new List<string> { "", "" };
            Customer MyCustomer = _context.Customer.Where(u => u.CustomerName == model.CustomerName)
                    .SingleOrDefault();
            if (MyCustomer == null)
            {
                if (ModelState.IsValid)
                {
                    Customer newCustomer = new Customer()
                    {
                        CustomerName = model.CustomerName
                    };
                    _context.Add(newCustomer);
                    _context.SaveChanges();
                }
                else
                {
                    ViewBag.errors = ModelState.Values;
                    ViewBag.values = new List<string> { model.CustomerName, "" };
                }
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                ViewBag.values = new List<string> { model.CustomerName, "This customer already exists! Please choose a different name." };
            }
            List<Customer> AllCustomers = _context.Customer.OrderByDescending(o => o.CreatedAt).ToList();
            ViewBag.allcustomers = AllCustomers;
            return View("Customers");
        }

        [HttpGet]
        [Route("Customers/Delete/{myID}")]
        public IActionResult DeleteCustomer(int myID)
        {
            ViewBag.errors = new List<string>();
            ViewBag.values = new List<string> {"", ""};
            Customer MyCustomer = _context.Customer.SingleOrDefault(c => c.CustomerId == myID);
            if(MyCustomer != null){
                ViewBag.values = new List<string> { "", ""+MyCustomer.CustomerName+" was deleted." };
                _context.Customer.Remove(MyCustomer);
                _context.SaveChanges();
            }
            List<Customer> AllCustomers = _context.Customer.OrderByDescending(o => o.CreatedAt).ToList();
            ViewBag.allcustomers = AllCustomers;
            return View("Customers");
        }






        [HttpGet]
        [Route("Settings")]
        public IActionResult Settings()
        {
            ViewBag.errors = new List<string>();
            ViewBag.values = new List<string> { "", "" };
            return View();
        }
    }
}
