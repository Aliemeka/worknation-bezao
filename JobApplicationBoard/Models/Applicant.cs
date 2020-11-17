using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace JobApplicationBoard.Models
{
    public class Applicant : IdentityUser
    {
        [Key]
        public int ApplicantId { get; set; }

        [Required, MaxLength(25, ErrorMessage = "Cannot exceed 25 characters")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        
        [Required, MaxLength(25, ErrorMessage = "Cannot exceed 25 characters")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email"), Required(ErrorMessage = "You have to enter your email")]
        [Display(Name ="Email address")]
        public string EmailAddress { get; set; }

        [Required]
        public string LevelofEduction { get; set; }
    }
}
