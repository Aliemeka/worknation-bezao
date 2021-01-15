using JobApplicationBoard.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationBoard.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobRepo _jobRepo;

        public JobController(IJobRepo jobRepo)
        {
            _jobRepo = jobRepo;
        }

        [Route("/all-jobs")]
        public IActionResult Index()
        {
            var model = _jobRepo.GetJobs();
            ViewBag.Jobs = model;
            return View();
        }
    }
}
