﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationBoard.ViewModels
{
    public class EditRolesViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a role name.")]
        [Display(Name ="Role name")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
