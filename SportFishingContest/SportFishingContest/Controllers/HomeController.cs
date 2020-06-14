using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportFishingContest.Interfaces;
using SportFishingContest.Models;
using SportFishingContest.ViewModels;

namespace SportFishingContest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IContestRepository _contestRepository;
        public HomeController(ILogger<HomeController> logger, IContestRepository contestRepository)
        {
            _logger = logger;
            _contestRepository = contestRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public IActionResult CreateContest()
        {
            var viewModel = new ContestViewModel();
            

            return View(viewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult CreateContest(ContestViewModel model)
        {

            if (ModelState.IsValid)
            {
                var newContest = new Contest();
                newContest.Date = model.Date;
                newContest.Name = model.ContestName;
                newContest = _contestRepository.Add(newContest);
                _contestRepository.Commit();

                return RedirectToAction("Index", "Home", new { id = newContest.Id });  //Redirect till tävlingen
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

