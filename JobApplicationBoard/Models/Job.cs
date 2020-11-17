using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [Required]
        public IEnumerable<string> RequiredSkills { get; set; }

        [Required, MinLength(50, ErrorMessage ="Description must contain at least 50 characters")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime TimeUploaded { get; set; }

        [Required]
        [ForeignKey("JobCategoryId")]
        public JobCategory JobCategory { get; set; }


    }

    public class JobCategory
    {
        [Key]
        public int JobCategoryId { get; set; }

        [Required, MinLength(6, ErrorMessage = "Category name as to be at list 6 characters long!")]
        [Display(Name = "Job Category")]
        public string CategoryName { get; set; }

        public ICollection<Job> Jobs { get; set; }

    }
}
