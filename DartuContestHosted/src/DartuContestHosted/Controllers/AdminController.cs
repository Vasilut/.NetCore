using DartuContestHosted.Models;
using DartuContestHosted.Services;
using DartuContestHosted.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DartuContestHosted.Controllers
{
    [Authorize]
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ElevViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newElev = new Rezultate
                {
                    Nume = model.Nume,
                    Clasa = model.Clasa,
                    Prenume = model.Prenume,
                    Scoala = model.Scoala,
                    P1 = model.P1,
                    P2 = model.P2,
                    P3 = model.P3
                };

                _participantResultsRepository.Add(newElev);
                _participantResultsRepository.Commit();
                return RedirectToAction("Index");
            }
            return View();
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
                if(!string.IsNullOrEmpty(model.Nume))
                {
                    stud.Nume = model.Nume;
                }

                if(!string.IsNullOrEmpty(model.Prenume))
                {
                    stud.Prenume = model.Prenume;
                }

                if(!string.IsNullOrEmpty(model.Scoala))
                {
                    stud.Scoala = model.Scoala;
                }

                stud.P1 = model.P1;
                stud.P2 = model.P2;
                stud.P3 = model.P3;
                
                //iterate over the property and see which can be updated
                //Type type = model.GetType();
                //var propertyInfo = type.GetProperties();

                //foreach (var item in propertyInfo)
                //{
                //    var value = item.GetValue(model, null);
                //    if (value != null)
                //    {
                //        //we can make update
                //        item.SetValue(stud, Convert.ChangeType(value, item.PropertyType), null);
                //    }
                //}

                _participantResultsRepository.Commit(); //update
                //update
                return RedirectToAction("Index");
            }
            return View(stud);
        }

    }
}
