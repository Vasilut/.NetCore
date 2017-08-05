using CoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new Restaurant() { Id = 1, Name = "Marty" };
            return new ObjectResult(model);
        }
    }
}
