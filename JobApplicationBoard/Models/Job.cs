using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplicationBoard.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        [Required, MinLength(6, ErrorMessage = "Job title must be at least 6 characters long")]
        [Display(Name ="Job Title")]
        public string Title { get; set; }

        [Required, MinLength(50, ErrorMessage ="Description must contain at least 50 characters")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime TimeUploaded { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Job Category must be at least 6 characters long")]
        public JobCategory JobCategory { get; set; }


    }
}
