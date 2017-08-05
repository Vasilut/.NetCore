using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    public class HomeController
    {
        [HttpGet]
        public string Index()
        {
            return "Hello from Dorna";
        }
    }
}
