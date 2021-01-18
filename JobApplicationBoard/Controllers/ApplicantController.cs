using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApplicationBoard.Models;
using JobApplicationBoard.Repositories;
using JobApplicationBoard.Services;
using JobApplicationBoard.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationBoard.Controllers
{
    [Authorize]
    public class ApplicantController : Controller
    {
        private readonly IJobRepo _jobRepo;
        private readonly IApplicantRepo _applicantRepo;
        private readonly IUploadFileService uploadFileService;
        private readonly IEmailService emailService;

        public ApplicantController(
            IJobRepo jobRepo, 
            IApplicantRepo applicantRepo, 
            IUploadFileService uploadFileService,
            IEmailService emailService)
        {
            _jobRepo = jobRepo;
            _applicantRepo = applicantRepo;
            this.uploadFileService = uploadFileService;
            this.emailService = emailService;
        }

        [HttpGet]
        [Route("/apply/{jobId:int}")]
        public IActionResult Apply(int jobId)
        {
            Job job = _jobRepo.GetJob(jobId);
            ViewBag.Job = job;
            return View();
        }


        [HttpPost]
        [Route("/apply/{jobId:int}")]
        public IActionResult Apply(int jobId, ApplyFormModel formModel, IFormFile photo, IFormFile resume)
        {
            if (ModelState.IsValid)
            {
                string photoPath = "";
                if (photo != null)
                {
                    photoPath = uploadFileService.UploadFile(photo);
                }

                string resumePath = "";
                if (resume != null)
                {
                    resumePath = uploadFileService.UploadFile(resume);
                }

                Applicant newApplicant = new Applicant
                {
                    FirstName = formModel.FirstName,
                    LastName = formModel.LastName,
                    EmailAddress = formModel.EmailAddress,
                    PortfolioLink = formModel.PortfolioLink,
                    LevelofEduction = formModel.LevelofEduction,
                    PhotoPath = photoPath,
                    ResumePath = resumePath,
                    AppliedJob = jobId
                };

                _applicantRepo.EnrolApplicant(newApplicant);
                emailService.SendConfirmation(newApplicant.EmailAddress, newApplicant.FirstName);
                emailService.SendEmail("Entry", "devgbono@gmail.com", "Admin");
                return RedirectToAction("Index", "Job");
            }

            Job job = _jobRepo.GetJob(jobId);
            ViewBag.Job = job;

            return View();
        }


    }
}
