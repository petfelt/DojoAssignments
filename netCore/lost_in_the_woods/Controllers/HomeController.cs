using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using the_wall.Models;
using DapperApp.Factory;

namespace the_wall.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailFactory trailFactory;
 
        public HomeController()
        {
            trailFactory = new TrailFactory();
        }


        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            ViewBag.trails = trailFactory.FindAll();
            return View();
        }

        [HttpGet]
        [Route("AddTrail")]
        public IActionResult AddTrail(){
            ViewBag.errors = new List<string>();
            ViewBag.values = new List<string> {"", "", "", "", "", ""};
            return View();
        }

        // Path from AddTrail to add trail to database.
        [HttpPost]
        [Route("AddTrail")]
        public IActionResult AddATrail(string Name, string Description, string TrailLength, string ElevationChange, string Longitude, string Latitude){
            Trail newTrail = new Trail()
            {
                Name = Name,
                Description = Description,
                TrailLength = TrailLength,
                ElevationChange = ElevationChange,
                Longitude = Longitude,
                Latitude = Latitude
            };
            TryValidateModel(newTrail);
            if (ModelState.IsValid)
            {
                trailFactory.Add(newTrail);
                return RedirectToAction("Index");
            }
            else
            {
            // If fail.
            ViewBag.errors = ModelState.Values;
            ViewBag.values = new List<string> {Name, Description, TrailLength, ElevationChange, Longitude, Latitude};
            Console.WriteLine(ViewBag.values[0]);

            return View("AddTrail");
            }
        }

        [HttpGet]
        [Route("Trails/{Passed_Id}")]
        public IActionResult ShowTrail(){
            ViewBag.trail = trailFactory.FindByID((Convert.ToInt32(RouteData.Values["Passed_Id"])));
            return View();
        }






        // OLD WALL CODE:
        //
        // [HttpPost]
        // [Route("Register")]
        // public IActionResult Create(string FirstName, string LastName, string EmailAddress, string Password, string ConfirmPassword)
        // {
        //     if(EmailAddress == null){
        //         // If they type in nothing, make it so it definitely won't match the email validator.
        //         EmailAddress = "abcd_nullify";
        //     }
        //     String ConfirmEmailAddress = EmailAddress;
        //     List<Dictionary<string, object>> ThisUser = _dbConnector.Query("SELECT * FROM users WHERE EmailAddress LIKE '%"+EmailAddress+"%'");
        //     foreach(Dictionary<string, object> dict in ThisUser){
        //         // If the email is found in the database, make it impossible to match.
        //         ConfirmEmailAddress = "false";
        //     }
        //     User newUser = new User()
        //     {
        //         FirstName = FirstName,
        //         LastName = LastName,
        //         EmailAddress = EmailAddress,
        //         Password = Password,
        //         ConfirmPassword = ConfirmPassword,
        //         ConfirmEmailAddress = ConfirmEmailAddress
        //     };
        //     TryValidateModel(newUser);
        //     if (ModelState.IsValid)
        //     {
        //         string QueryString = $"INSERT INTO users (FirstName, LastName, EmailAddress, Password, createdAt, updatedAt) VALUES ('{newUser.FirstName}','{newUser.LastName}','{newUser.EmailAddress}','{newUser.Password}',NOW(), NOW())";
        //         _dbConnector.Execute(QueryString);
        //         HttpContext.Session.SetString("myEmail", EmailAddress);
        //         HttpContext.Session.SetInt32("access", 1);
        //         List<Dictionary<string, object>> MyUser = _dbConnector.Query("SELECT * FROM users WHERE EmailAddress LIKE '%"+EmailAddress+"%'");
        //         foreach(Dictionary<string, object> dict in MyUser){
        //             foreach(object list in dict){
        //                 string str = list.ToString();
        //                 if(str[1] == 'i'){ // If it's an id.
        //                     HttpContext.Session.SetString("UserID", str.Substring(5, str.Length-6));
        //                 } 
        //             }
        //         }
        //         return RedirectToAction("The_Wall");
        //     }
        //     else
        //     {
        //         ViewBag.errors = ModelState.Values;
        //         if(EmailAddress == "abcd_nullify"){
        //             // Correct the previously changed entry so it saves as blank in the ViewBag.
        //             EmailAddress = "";
        //         }
        //         ViewBag.values = new List<string> {FirstName, LastName, EmailAddress, Password, ConfirmPassword};
        //         return View("Index");
        //     }

        // }



        // [HttpPost]
        // [Route("Login")]
        // public IActionResult Login(string EmailAddress, string Password)
        // {
        //     List<Dictionary<string, object>> ThisUser = _dbConnector.Query("SELECT * FROM users WHERE EmailAddress LIKE '%"+EmailAddress+"%'");
        //     string ConfirmEmailAddress = "";
        //     string ConfirmPassword = "";
        //     // Grab the potential email & password from database.
        //     // This is a hacky method I did before I figured out how to actually look at each value
        //     // In the dictionary. I could fix this up, but I am currently under the weather.
        //     // It's somewhat less efficient due to plenty of extra string/substring creation, but it does the job.
        //     // Reference later code to see how it could be way more efficient. (In .cshtml section, mostly.)
        //     foreach(Dictionary<string, object> dict in ThisUser){
        //         foreach(object list in dict){
        //             string str = list.ToString();
        //             if(str[1] == 'E'){ // If it's an email.
        //                 ConfirmEmailAddress = str.Substring(15, str.Length-16);
        //             }
        //             if(str[1] == 'P'){ // If it's a password.
        //                 ConfirmPassword = str.Substring(11, str.Length-12);
        //             }
        //             if(str[1] == 'i'){ // If it's an ID.
        //                 HttpContext.Session.SetString("UserID", str.Substring(5, str.Length-6));
        //             }   
        //         }
        //     }
        //     // Put in confirmations vs user inputs into login model and try it.
        //     LoginUser tempUser = new LoginUser()
        //     {
        //         EmailAddress = EmailAddress,
        //         ConfirmEmailAddress = ConfirmEmailAddress,
        //         Password = Password,
        //         ConfirmPassword = ConfirmPassword
        //     };
        //     TryValidateModel(tempUser);
        //     if (ModelState.IsValid)
        //     {
        //         // Successfully logged in.
        //         HttpContext.Session.SetString("myEmail", EmailAddress);
        //         HttpContext.Session.SetInt32("access", 1);
        //         return RedirectToAction("The_Wall");
        //     }
        //     else
        //     {
        //         // Login failed.
        //         ViewBag.errors = ModelState.Values;
        //         ViewBag.values = new List<string> {"", "", EmailAddress, Password, ""};
        //         return View("Index");
        //     }            
        // }



        // [HttpGet]
        // [Route("the_wall")]
        // public IActionResult The_Wall()
        // {
        //     // Need to make viewbags of all messages, comments, and users.
        //     // You need users so you can grab their names using their IDs.
        //     List<Dictionary<string, object>> Messages = _dbConnector.Query("SELECT * FROM messages ORDER BY createdAt DESC");
        //     List<Dictionary<string, object>> Comments = _dbConnector.Query("SELECT * FROM comments ORDER BY createdAt");
        //     List<Dictionary<string, object>> Users = _dbConnector.Query("SELECT * FROM users");

        //     ViewBag.myID = HttpContext.Session.GetString("UserID");
        //     ViewBag.messages = Messages;
        //     ViewBag.comments = Comments;
        //     ViewBag.Users = Users;
        //     ViewBag.errors = new List<string>();
        //     ViewBag.values = new List<string> {"", "", "", "", ""};
        //     if(HttpContext.Session.GetInt32("access") > 0){
        //         return View("The_Wall");
        //     }
        //     return View("Index");
            
        // }



        // [HttpPost]
        // [Route("Post_Message")]
        // public IActionResult Post_Message(string message)
        // {
        //     Message newMessage = new Message()
        //     {
        //         Post = message,
        //         UserID = HttpContext.Session.GetString("UserID")
        //     };
        //     TryValidateModel(newMessage);
        //     if (ModelState.IsValid)
        //     {
        //         string QueryString = $"INSERT INTO messages (users_id, Message, createdAt, updatedAt) VALUES ('{newMessage.UserID}','{newMessage.Post}',NOW(), NOW())";
        //         _dbConnector.Execute(QueryString);
        //         return RedirectToAction("The_Wall");
        //     }
        //     else
        //     {
        //         List<Dictionary<string, object>> Messages = _dbConnector.Query("SELECT * FROM messages ORDER BY createdAt DESC");
        //         List<Dictionary<string, object>> Comments = _dbConnector.Query("SELECT * FROM comments ORDER BY createdAt");
        //         List<Dictionary<string, object>> Users = _dbConnector.Query("SELECT * FROM users");

        //         ViewBag.myID = HttpContext.Session.GetString("UserID");
        //         ViewBag.messages = Messages;
        //         ViewBag.comments = Comments;
        //         ViewBag.Users = Users;
        //         ViewBag.errors = ModelState.Values;
        //         return View("The_Wall");
        //     }
        // }



        // [HttpPost]
        // [Route("Post_Comment")]
        // public IActionResult Post_Comment(string message_id, string comment)
        // {
        //     Comment newComment = new Comment()
        //     {
        //         Post = comment,
        //         UserID = HttpContext.Session.GetString("UserID"),
        //         MessageID = message_id
        //     };
        //     TryValidateModel(newComment);
        //     if (ModelState.IsValid)
        //     {
        //         string QueryString = $"INSERT INTO comments (messages_id, users_id, comment, createdAt, updatedAt) VALUES ('{newComment.MessageID}','{newComment.UserID}','{newComment.Post}',NOW(), NOW())";
        //         _dbConnector.Execute(QueryString);
        //         return RedirectToAction("The_Wall");
        //     }
        //     else
        //     {
        //         List<Dictionary<string, object>> Messages = _dbConnector.Query("SELECT * FROM messages ORDER BY createdAt DESC");
        //         List<Dictionary<string, object>> Comments = _dbConnector.Query("SELECT * FROM comments ORDER BY createdAt");
        //         List<Dictionary<string, object>> Users = _dbConnector.Query("SELECT * FROM messages");

        //         ViewBag.myID = HttpContext.Session.GetString("UserID");
        //         ViewBag.messages = Messages;
        //         ViewBag.comments = Comments;
        //         ViewBag.Users = Users;
        //         ViewBag.errors = ModelState.Values;
        //         return View("The_Wall");
        //     }
        // }


        // [HttpPost]
        // [Route("Delete_Message")]
        // public IActionResult Delete_Message(string message_id)
        // {
        //     DeleteMessage newDelete = new DeleteMessage()
        //     {
        //         Delete = "" // Force it to fail, so we send "Message deleted" message.
        //     };
        //     TryValidateModel(newDelete);
        //     if (ModelState.IsValid) // This should never happen. But just in case of hacky hacks...
        //     {
        //         List<Dictionary<string, object>> Messages = _dbConnector.Query("SELECT * FROM messages ORDER BY createdAt DESC");
        //         List<Dictionary<string, object>> Comments = _dbConnector.Query("SELECT * FROM comments ORDER BY createdAt");
        //         List<Dictionary<string, object>> Users = _dbConnector.Query("SELECT * FROM users");

        //         ViewBag.myID = HttpContext.Session.GetString("UserID");
        //         ViewBag.messages = Messages;
        //         ViewBag.comments = Comments;
        //         ViewBag.Users = Users;
        //         ViewBag.errors = ModelState.Values;
        //         return View("The_Wall");
        //     }
        //     else // Where everything should actually happen.
        //     {
        //         string QueryString = $"DELETE FROM comments WHERE messages_id='"+message_id+"'";
        //         _dbConnector.Execute(QueryString);
        //         QueryString = $"DELETE FROM messages WHERE id='"+message_id+"'";
        //         _dbConnector.Execute(QueryString);

        //         List<Dictionary<string, object>> Messages = _dbConnector.Query("SELECT * FROM messages ORDER BY createdAt DESC");
        //         List<Dictionary<string, object>> Comments = _dbConnector.Query("SELECT * FROM comments ORDER BY createdAt");
        //         List<Dictionary<string, object>> Users = _dbConnector.Query("SELECT * FROM users");

        //         ViewBag.myID = HttpContext.Session.GetString("UserID");
        //         ViewBag.messages = Messages;
        //         ViewBag.comments = Comments;
        //         ViewBag.Users = Users;
        //         ViewBag.errors = ModelState.Values;
        //         return View("The_Wall");
        //     }
        // }





        // // Logout.

        // [HttpGet]
        // [Route("Logout")]
        // public IActionResult Refresh(){
        //     HttpContext.Session.Clear();
        //     return RedirectToAction("Index");
        // }


        // // Redirect routes in case people try to directly visit POST links:
        
        // [HttpGet]
        // [Route("Register")]
        // public IActionResult Refresh2()
        // {
        //     // Just in case users go to this page directly for some reason.
        //     return RedirectToAction("Index");
        // }
        // [HttpGet]
        // [Route("Login")]
        // public IActionResult Refresh3()
        // {
        //     // Just in case users go to this page directly for some reason.
        //     return RedirectToAction("Index");
        // }

        // [HttpGet]
        // [Route("Delete_Message")]
        // public IActionResult Refresh4()
        // {
        //     // Just in case users go to this page directly for some reason.
        //     return RedirectToAction("Index");
        // }

        // [HttpGet]
        // [Route("Post_Message")]
        // public IActionResult Refresh5()
        // {
        //     // Just in case users go to this page directly for some reason.
        //     return RedirectToAction("Index");
        // }
        // [HttpGet]
        // [Route("Post_Comment")]
        // public IActionResult Refresh6()
        // {
        //     // Just in case users go to this page directly for some reason.
        //     return RedirectToAction("Index");
        // }
    }
}
