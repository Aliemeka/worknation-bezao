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
    public class AdminController : Controller
    {
        private readonly IJobRepo _jobRepo;
        private readonly IApplicantRepo _applicant;

        public AdminController(IJobRepo jobRepo, IApplicantRepo applicant)
        {
            _jobRepo = jobRepo;
            _applicant = applicant;
        }

        
        [Route("/admin")]
        public IActionResult Index()
        {
            return View();
        }


        [Route("/admin/all-applicants")]
        public IActionResult ViewApplicants()
        {
            return View();
        }

        [HttpGet]
        [Route("/admin/add-job")]
        public IActionResult CreateJob()
        {
            return View();
        }


        [HttpPost]
        [Route("/admin/add-job")]
        public IActionResult CreateJob(Job job)
        {
            Job newJob = _jobRepo.AddJob(job);
            return RedirectToAction("all-jobs/" + newJob.JobId);
        }

        
    }
}
