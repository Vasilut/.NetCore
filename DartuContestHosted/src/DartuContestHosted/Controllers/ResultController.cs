using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DartuContestHosted.Models;
using DartuContestHosted.Services;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DartuContestHosted.Controllers
{
    [Authorize]
    public class ResultController : Controller
    {
        private IParticipantResultsRepository _participantResultsRepository;
        public ResultController(IParticipantResultsRepository participantResultsRepository)
        {
            _participantResultsRepository = participantResultsRepository;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RezultateElevi(int id)
        {
            var results = _participantResultsRepository.GetResults().Where(part => part.Clasa == id).ToList();
            return View(results);
        }
    }
}
