using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MyApplication.Controllers {
    public class PortfolioController : Controller {

        [HttpGet]
        [Route("")]
        public IActionResult homePage() {
            return View();
        }

        [HttpPost]
        [Route("result")]
        public IActionResult result(string name, string location, string language, string comment) {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            return View();
        }
        
    }
}