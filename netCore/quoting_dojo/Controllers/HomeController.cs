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
            return View();
        }

        [HttpPost]
        [Route("Quotes")]

        public IActionResult Create(string Name, string Content)
        {
            Quote newQuote = new Quote(){
                Name = Name,
                Content = Content
            };
            TryValidateModel(newQuote);
            if(ModelState.IsValid){
                string QueryString = $"INSERT INTO quotes (quote, name, createdAt) VALUES ('{newQuote.Content}','{newQuote.Name}',NOW())";
                _dbConnector.Execute(QueryString);
                return RedirectToAction("Quotes");
            } else {
                ViewBag.errors = ModelState.Values;
                return View("Index");
            }
            
        }


        [HttpGet]
        [Route("Quotes")]
        public IActionResult Quotes(){
            List<Dictionary<string, object>> AllQuotes = _dbConnector.Query("SELECT * FROM quotes ORDER BY createdAt DESC");
            ViewBag.AllQuotes = AllQuotes;
            return View();
        }

    }
}
