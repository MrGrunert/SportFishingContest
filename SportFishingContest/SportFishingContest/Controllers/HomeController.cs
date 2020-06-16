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
        private IParticipantRepository _participantRepository;
        private IFishRepository _fishRepository;
        public HomeController(ILogger<HomeController> logger, IContestRepository contestRepository, IParticipantRepository participantRepository, IFishRepository fishRepository)
        {
            _logger = logger;
            _contestRepository = contestRepository;
            _participantRepository = participantRepository;
            _fishRepository = fishRepository;
        }

        public IActionResult Index()
        {
            var model = new ContestViewModel();
            model.Contests = _contestRepository.GetAllContests().OrderByDescending(d => d.Date).ToList();
            return View(model);
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

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public IActionResult Contest(Guid id)
        {
            var theContest = _contestRepository.GetContestById(id);
            var participants = GetParticipantsByContestId(id);
            var viewModel = new ContestViewModel
            {
                Id = theContest.Id,
                ContestName = theContest.Name,
                Date = theContest.Date,
                Participants = participants
            };


            return View(viewModel);
        }

        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public IActionResult Contest(ContestViewModel model)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        var newContest = new Contest();
        //        newContest.Date = model.Date;
        //        newContest.Name = model.ContestName;
        //        newContest = _contestRepository.Add(newContest);
        //        _contestRepository.Commit();

        //        return RedirectToAction("Index", "Home", new { id = newContest.Id });  //Redirect till tävlingen
        //    }

        //    return View(model);
        //}
        [HttpPost]
        public IActionResult AddParticipant(ContestViewModel model)
        {

            var participant = new Participant();
            participant.ContestId = model.Id;
            participant.Name = model.Participant.Name;
            _participantRepository.Add(participant);
            _participantRepository.Commit();

            return RedirectToAction("Contest", "Home", new { id = model.Id });
        }

        public IActionResult addFish(ContestViewModel model)
        {
            var fish = new Fish();
            fish.ParticipantId = model.Fish.ParticipantId;
            fish.Length = model.Fish.Length;
            _fishRepository.Add(fish);
            _fishRepository.Commit();
            return RedirectToAction("Contest", "Home", new { id = model.Id });
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

        private List<Participant> GetParticipantsByContestId(Guid contestId)
        {
            var participants = _participantRepository.GetParticipantsByContestId(contestId);
            return participants.ToList();
        }
    }
}

