using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MyApplication.Controllers {
    public class CodewordController : Controller {

        [HttpGet]
        [Route("")]
        public IActionResult homePage() {
            if(HttpContext.Session.GetInt32("counter") == null){
                HttpContext.Session.SetInt32("counter", 1);
            }
            if(HttpContext.Session.GetString("randomCode") == null){
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var stringChars = new char[14];
                System.Random rand = new System.Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[rand.Next(chars.Length)];
                }
                HttpContext.Session.SetString("randomCode", new string(stringChars));
            }
            
            @ViewBag.randomCode = HttpContext.Session.GetString("randomCode");
            @ViewBag.counter = ""+(HttpContext.Session.GetInt32("counter")).ToString();
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult result() {
            // Increase count here.
            int? temp = HttpContext.Session.GetInt32("counter");
            temp = temp+1;
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[14];
            System.Random rand = new System.Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[rand.Next(chars.Length)];
            }
            HttpContext.Session.SetString("randomCode", new string(stringChars));

            HttpContext.Session.SetInt32("counter",(int)temp);
            return RedirectToAction("homePage");
        }

        [HttpPost]
        [Route("clear")]
        public IActionResult clear() {
            HttpContext.Session.Clear();
            return RedirectToAction("homePage");
        }
        
    }
}