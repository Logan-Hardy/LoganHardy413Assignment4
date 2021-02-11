using LoganHardy413Assignment4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LoganHardy413Assignment4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> restaurantList = new List<string>();

            foreach (Restaurant r in Restaurant.GetRestaurants())
            {
                //if FavoriteDish or PhoneNumber is null, display default values 
                string? FavDish = r.FavoriteDish ?? "It’s all tasty!";
                string? PhoneNum = r.PhoneNumber ?? "None";

                //If website has the default value of "Coming soon", do not insert into an "a" tag 
                if (r.Website == "Coming soon")
                {
                    //format top 5 restaurant information to look nice
                    restaurantList.Add(string.Format($"<strong>#{r.RestaurantRank}:</strong> {r.RestaurantName} <br> " +
                        $"<strong>Favorite Dish:</strong> {FavDish} <br> " +
                        $"<strong>Address:</strong> {r.Address} <br> " +
                        $"<strong>Phone Number:</strong> {PhoneNum} <br> " +
                        $"<strong>Website:</strong> {r.Website}<br><br>"));
                }
                //display website as a link
                else
                {
                    //format top 5 restaurant information to look nice
                    restaurantList.Add(string.Format($"<strong>#{r.RestaurantRank}:</strong> {r.RestaurantName} <br> " +
                        $"<strong>Favorite Dish:</strong> {FavDish} <br> " +
                        $"<strong>Address:</strong> {r.Address} <br> " +
                        $"<strong>Phone Number:</strong> {PhoneNum} <br> " +
                        $"<strong>Website:</strong> <a href='{r.Website}'> {r.Website}</a><br><br>"));
                }

            }

            return View(restaurantList);
        }

        [HttpGet]
        public IActionResult AddRestaurant()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRestaurant(AddRestaurant appResponse)
        {
            //if user fills in all fields correctly, save in TempStorage and return Confirmation view
            if (ModelState.IsValid)
            {
                TempStorage.AddApplication(appResponse);
                return View("Confirmation", appResponse);
            }
            //else display model validations on current page view
            else
            {
                return View();
            }
        }

        public IActionResult MyRestaurants()
        {
            return View(TempStorage.Applications);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
