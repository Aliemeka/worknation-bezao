using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplicationBoard.Models
{
    public class Applicant
    {
        [Key]
        public int ApplicantId { get; set; }

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
        [Display(Name ="Email address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name ="Level of Education")]
        public string LevelofEduction { get; set; }

        [ForeignKey("JobId")]
        public Job AppliedJob { get; set; }
    }
}
