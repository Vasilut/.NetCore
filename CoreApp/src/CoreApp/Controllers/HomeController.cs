using CoreApp.Models;
using CoreApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var restaurants = _restaurantData.GetAll();
            return View(restaurants);
        }
    }
}
