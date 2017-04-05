using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MyApplication.Controllers {
    public class PortfolioController : Controller {

        [HttpGet]
        [Route("")]
        public IActionResult homePage() {
            return View();
        }

        [HttpGet]
        [Route("Projects")]
        public IActionResult projects() {
            return View();
        }

        [HttpGet]
        [Route("Contact")]
        public IActionResult contact() {
            return View();
        }
        
    }
}