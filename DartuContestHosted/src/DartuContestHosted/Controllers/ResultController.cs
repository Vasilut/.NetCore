using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DartuContestHosted.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DartuContestHosted.Controllers
{
    public class ResultController : Controller
    {
        private ResultsContext _dbContext;
        public ResultController(ResultsContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var results = _dbContext.Rezultate.ToList();
            return View(results);
        }
    }
}
