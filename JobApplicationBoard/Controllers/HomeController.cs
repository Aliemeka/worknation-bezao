using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JobApplicationBoard.Models;
using JobApplicationBoard.Repositories;

namespace JobApplicationBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJobRepo _jobRepo;

        public HomeController(ILogger<HomeController> logger, IJobRepo jobRepo)
        {
            _logger = logger;
            _jobRepo = jobRepo;
        }


        public ViewResult Index()
        {
            var model = _jobRepo.GetJobs();
            ViewBag.Jobs = model;
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/about")]
        public IActionResult About()
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
