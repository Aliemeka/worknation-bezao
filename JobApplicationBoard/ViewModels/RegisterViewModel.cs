using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationBoard.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Please enter an email address!")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address!")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please enter a password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$",
            ErrorMessage ="Password must be between 8 to 15 characters long and should contain at least uppercase character, " +
            "lowercase character, alphanumeric character and special character!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm password")]
        [Compare("Password", ErrorMessage ="Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
