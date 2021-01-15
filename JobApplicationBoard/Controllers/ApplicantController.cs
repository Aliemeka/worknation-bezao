using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApplicationBoard.Models;
using JobApplicationBoard.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationBoard.Controllers
{
    [Authorize]
    public class ApplicantController : Controller
    {
        private readonly IJobRepo _jobRepo;
        private readonly IApplicantRepo _applicantRepo;

        public ApplicantController(IJobRepo jobRepo, IApplicantRepo applicantRepo)
        {
            _jobRepo = jobRepo;
            _applicantRepo = applicantRepo;
        }

        [HttpGet]
        [Route("/apply/{jobId:int}")]
        public IActionResult Apply(int jobId)
        {
            Job job = _jobRepo.GetJob(jobId);
            ViewBag.Job = job;
            return View();
        }
    }
}
