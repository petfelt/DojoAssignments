using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MyApplication.Controllers
{
    public class DojodachiController : Controller
    {
        System.Random rand = new System.Random();

        [HttpGet]
        [Route("")]
        public IActionResult refresh()
        {
            return RedirectToAction("homePage");
        }

        [HttpGet]
        [Route("dojodachi")]
        public IActionResult homePage()
        {
            if (HttpContext.Session.GetInt32("happiness") == null)
            {
                HttpContext.Session.SetInt32("happiness", 20);
            }
            if (HttpContext.Session.GetInt32("fullness") == null)
            {
                HttpContext.Session.SetInt32("fullness", 20);
            }
            if (HttpContext.Session.GetInt32("energy") == null)
            {
                HttpContext.Session.SetInt32("energy", 50);
            }
            if (HttpContext.Session.GetInt32("meals") == null)
            {
                HttpContext.Session.SetInt32("meals", 3);
            }
            if (HttpContext.Session.GetString("response") == null)
            {
                HttpContext.Session.SetString("response", "Welcome to Admiral Ackbar: The Daycare Experience! Click a button below to begin.");
            }
            if (HttpContext.Session.GetInt32("playState") == null)
            {
                HttpContext.Session.SetInt32("playState", 0);
            } else if (HttpContext.Session.GetInt32("fullness") <= 0 || HttpContext.Session.GetInt32("happiness") <= 0)
            {
                HttpContext.Session.SetString("response", "Admiral Ackbar has passed away...");
                HttpContext.Session.SetInt32("playState", -1);
                if(HttpContext.Session.GetInt32("fullness") < 0) {
                    HttpContext.Session.SetInt32("fullness", 0);
                }
                if(HttpContext.Session.GetInt32("happiness") < 0) {
                    HttpContext.Session.SetInt32("happiness", 0);
                }

            } else if (HttpContext.Session.GetInt32("fullness") > 100 && HttpContext.Session.GetInt32("happiness") > 100 && HttpContext.Session.GetInt32("energy") > 100)
            {
                HttpContext.Session.SetString("response", "Congratulations! Admiral Ackbar is healthy enough to leave daycare! You Won!");
                HttpContext.Session.SetInt32("playState", 1);
            }


            @ViewBag.happiness = (HttpContext.Session.GetInt32("happiness")).ToString();
            @ViewBag.fullness = (HttpContext.Session.GetInt32("fullness")).ToString();
            @ViewBag.energy = (HttpContext.Session.GetInt32("energy")).ToString();
            @ViewBag.meals = (HttpContext.Session.GetInt32("meals")).ToString();
            @ViewBag.response = HttpContext.Session.GetString("response");
            @ViewBag.playState = HttpContext.Session.GetInt32("playState");
            return View();
        }

        [HttpPost]
        [Route("feed")]
        public IActionResult feed()
        {
            // Feeding your Dojodachi costs 1 meal and gains a random amount of fullness between 5 and 10 (you cannot feed your Dojodachi if you do not have meals)
            int? meals = HttpContext.Session.GetInt32("meals");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            if (rand.Next(0, 4) == 0 && meals > 0)
            { // 25% chance of not liking the food.
                meals -= 1;
                HttpContext.Session.SetInt32("meals", (int)meals);
                HttpContext.Session.SetString("response", "Your Admiral didn't really like that meal...");
                return RedirectToAction("homePage");
            }
            if (meals > 0)
            { // If you still have meals to give the Admiral...
                int string_fullness = rand.Next(5, 11);
                fullness += string_fullness;
                meals -= 1;
                HttpContext.Session.SetInt32("meals", (int)meals);
                HttpContext.Session.SetInt32("fullness", (int)fullness);
                HttpContext.Session.SetString("response", "You fed your Admiral! -1 Meal, Fullness +" + string_fullness + ".");
                return RedirectToAction("homePage");
            }
            // If no meals, say you don't have meals.
            HttpContext.Session.SetString("response", "You cannot feed your Admiral if you don't have any meals left!");
            return RedirectToAction("homePage");
        }

        [HttpPost]
        [Route("play")]
        public IActionResult play()
        {
            // Playing with your Dojodachi costs 5 energy and gains a random amount of happiness between 5 and 10
            // Every time you play with or feed your dojodachi there should be a 25% chance that it won't like it. Energy or meals will still decrease, but happiness and fullness won't change.
            int? energy = HttpContext.Session.GetInt32("energy");
            int? happiness = HttpContext.Session.GetInt32("happiness");
            if (rand.Next(0, 4) == 0 && energy >= 5)
            { // 25% chance of not liking play time.
                energy -= 5;
                HttpContext.Session.SetInt32("energy", (int)energy);
                HttpContext.Session.SetString("response", "Your Admiral didn't really enjoy playing with you that time...");
                return RedirectToAction("homePage");
            }
            if (energy >= 5)
            {
                int string_happiness = rand.Next(5, 11);
                happiness += string_happiness;
                energy -= 5;
                HttpContext.Session.SetInt32("energy", (int)energy);
                HttpContext.Session.SetInt32("happiness", (int)happiness);
                HttpContext.Session.SetString("response", "You played with your Admiral! Energy -5, Happiness +" + string_happiness + ".");
                return RedirectToAction("homePage");
            }
            HttpContext.Session.SetString("response", "You don't have enough energy to play with your Admiral!");
            return RedirectToAction("homePage");
        }

        [HttpPost]
        [Route("work")]
        public IActionResult work()
        {
            // Working costs 5 energy and earns between 1 and 3 meals
            int? meals = HttpContext.Session.GetInt32("meals");
            int? energy = HttpContext.Session.GetInt32("energy");
            if (energy >= 5)
            {
                int string_meals = rand.Next(1, 4);
                meals += string_meals;
                energy -= 5;
                HttpContext.Session.SetInt32("meals", (int)meals);
                HttpContext.Session.SetInt32("energy", (int)energy);
                HttpContext.Session.SetString("response", "Admiral Ackbar did some work! Energy -5, +" + string_meals + " Meals.");
                return RedirectToAction("homePage");
            }
            HttpContext.Session.SetString("response", "Admiral Ackbar doesn't have enough energy to work!");
            return RedirectToAction("homePage");
        }

        [HttpPost]
        [Route("sleep")]
        public IActionResult sleep()
        {
            // Sleeping earns 15 energy and decreases fullness and happiness each by 5
            int? energy = HttpContext.Session.GetInt32("energy");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? happiness = HttpContext.Session.GetInt32("happiness");
            energy += 15;
            fullness -= 5;
            happiness -= 5;
            HttpContext.Session.SetInt32("happiness", (int)happiness);
            HttpContext.Session.SetInt32("energy", (int)energy);
            HttpContext.Session.SetInt32("fullness", (int)fullness);
            HttpContext.Session.SetString("response", "Admiral Ackbar took a nap! Energy +15, Fullness -5, Happiness -5.");
            return RedirectToAction("homePage");
        }

        [HttpPost]
        [Route("clear")]
        public IActionResult clear()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("homePage");
        }
    }
}