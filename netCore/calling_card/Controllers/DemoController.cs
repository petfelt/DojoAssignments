using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MyApplication.Controllers {
    public class DemoController : Controller {

        [HttpGet]
        [Route("")]
        public string Index() {
            return "Welcome! Type 'Card/{FirstName}/{LastName}/{Age}/{FavoriteColor}' into the browser bar to get to the calling card!";
        }

        [HttpGet]
        [Route("Card/myFavoriteNumber")]
        public int FavoriteNumber() {
            return 666;
        }

        [HttpGet]
        [Route("helloWorld")]
        public IActionResult helloWorld() {
            return View();
        }



        [HttpGet]
        [Route("Card/{FirstName}/{LastName}/{Age}/{FavoriteColor}")]
        public JsonResult ShowTemplate(string FirstName, string LastName, string Age, string FavoriteColor) {
            return Json(new{MyFirstName = FirstName, MyLastName = LastName, MyAge = Age, MyColor = FavoriteColor});
        }
        
    }
}