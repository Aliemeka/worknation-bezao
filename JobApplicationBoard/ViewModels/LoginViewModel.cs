using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationBoard.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter an email address!")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
