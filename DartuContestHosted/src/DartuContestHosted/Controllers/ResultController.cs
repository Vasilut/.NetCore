using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DartuContestHosted.Models;
using DartuContestHosted.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DartuContestHosted.Controllers
{
    public class ResultController : Controller
    {
        private ResultsContext _dbContext;
        private IParticipantResultsRepository _participantResultsRepository;
        public ResultController(IParticipantResultsRepository participantResultsRepository)
        {
            _participantResultsRepository = participantResultsRepository;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            var results = _participantResultsRepository.GetResults();
            return View(results);
        }

        [HttpGet]
        public IActionResult RezultateElevi(int id)
        {
            //fitered by ID:TBD
            var results = _participantResultsRepository.GetResults();
            return View(results);
        }
    }
}
