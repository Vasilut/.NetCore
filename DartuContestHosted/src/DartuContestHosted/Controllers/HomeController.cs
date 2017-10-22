using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DartuContestHosted.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Result()
        {
            ViewData["Message"] = "Result Page.";
            return View();
        }
        
        public IActionResult Error()
        {
            return View();
        }
    }
}
