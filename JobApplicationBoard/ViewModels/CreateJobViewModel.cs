using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationBoard.ViewModels
{
    public class CreateJobViewModel
    {
        [Required, MinLength(6, ErrorMessage = "Job title must be at least 6 characters long")]
        [Display(Name = "Job Title")]
        public string Title { get; set; }

        [Required, MinLength(50, ErrorMessage = "Description must contain at least 50 characters")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime TimeUploaded { get; set; }

        [Required]
        public string JobCategory { get; set; }
    }
}
