using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MyApplication.Controllers {
    public class DateTimeController : Controller {

        [HttpGet]
        [Route("")]
        public IActionResult dateTime() {
            return View();
        }
        
    }
}