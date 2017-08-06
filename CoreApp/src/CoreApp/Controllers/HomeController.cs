using CoreApp.Entities;
using CoreApp.Services;
using CoreApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    public class HomeController : Controller
    {
        private IGreeter _greeter;
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetGreeting();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            var newRestaurant = new Restaurant()
            {
                Cuisine = model.Cuisine,
                Name = model.Name
            };

            newRestaurant = _restaurantData.Add(newRestaurant);
            return View("Details", newRestaurant);
        }
    }
}
