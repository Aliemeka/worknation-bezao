using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace JobApplicationBoard.Models
{
    public class AppUser : IdentityUser
    {
        public bool? IsAdmin { get; set; }
    }
}
