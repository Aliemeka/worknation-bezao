using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationBoard.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Please enter an email address!")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address!")]
        public string Email { get; set; }
    }
}
