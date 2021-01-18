using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JobApplicationBoard.Models;
using Microsoft.AspNetCore.Http;

namespace JobApplicationBoard.ViewModels
{
    public class ApplyFormModel
    {

        [Required(ErrorMessage = "This field cannot be empty")]
        [MaxLength(25, ErrorMessage = "Cannot exceed 25 characters")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field cannot be empty")]
        [MaxLength(25, ErrorMessage = "Cannot exceed 25 characters")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        [Required(ErrorMessage = "You have to enter your email")]
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }

        [Url]
        [Required(ErrorMessage = "Please enter a valid url")]
        [Display(Name = "Link to portfolio")]
        public string PortfolioLink { get; set; }

        [Required]
        [Display(Name = "Level of Education")]
        public string LevelofEduction { get; set; }

        /*
        [Required(ErrorMessage = "Please upload your photo")]
        [Display(Name ="Passport Photo")]
        public IFormFile PhotoFile { get; set; }

        [Required(ErrorMessage = "Please upload your resume")]
        [Display(Name ="Resume")]
        public IFormFile ResumeFile { get; set; }
        */
    }
}
