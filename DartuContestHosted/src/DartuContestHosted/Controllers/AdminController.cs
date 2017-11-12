using DartuContestHosted.Services;
using DartuContestHosted.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartuContestHosted.Controllers
{
    public class AdminController : Controller
    {
        private IParticipantResultsRepository _participantResultsRepository;

        public AdminController(IParticipantResultsRepository participantResultsRepository)
        {
            _participantResultsRepository = participantResultsRepository;
        }

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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _participantResultsRepository.GetResults().Where(part => part.Id == id).FirstOrDefault();
            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _participantResultsRepository.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            _participantResultsRepository.Delete(model);
            _participantResultsRepository.Commit();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ElevViewModel model)
        {
            var stud = _participantResultsRepository.Get(id);
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.Nume))
                {
                    stud.Nume = model.Nume;
                }
                _participantResultsRepository.Commit(); //update

                //update
                return RedirectToAction("Index");

            }
            return View(stud);
        }

    }
}
