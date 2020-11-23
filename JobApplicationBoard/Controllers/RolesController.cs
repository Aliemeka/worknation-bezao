using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApplicationBoard.Models;
using JobApplicationBoard.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationBoard.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }


        [Route("/roles")]
        public IActionResult Index()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        [Route("/roles/create-role")]
        public IActionResult CreateRole()
        {
            return View();
        }


        [HttpPost]
        [Route("/roles/create-role")]
        public async Task<IActionResult> CreateRoleAsync(CreateRoleViewModel model) //Creates a new identity role
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        [Route("/roles/edit-role")]
        public async Task<IActionResult> EditRole(string id) //Edits identity role
        {
            var role = await roleManager.FindByIdAsync(id);

            // If the id is invalid, shows 404 page
            if(role == null)
            {
                return View("error404");
            }

            // Updates model with role
            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name,

            };

            foreach(var user in userManager.Users)
            {
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }


            return View(model);
        }

        [HttpPost]
        [Route("/roles/edit-role")]
        public async Task<IActionResult> EditRole(EditRoleViewModel model) //Edits identity role
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            // If the id is invalid, shows 404 page
            if (role == null)
            {
                return View("error404");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }


                return View(model);
            }

            
        }

        [HttpGet]
        [Route("roles/manage-role-users")]
        public async Task<IActionResult> ManageRoleUsers(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return View("error404");
            }

            var model = new List<UserRoleViewModel>();

            foreach(var user in userManager.Users)
            {
                var userViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userViewModel.IsChecked = true;
                }
                else
                {
                    userViewModel.IsChecked = false;
                }

                model.Add(userViewModel);
            }

            return View(model);
        }

        [HttpPost]
        [Route("roles/manage-role-users")]
        public async Task<IActionResult> ManageRoleUsers(List<UserRoleViewModel> model, string roleid)
        {
            var role = await roleManager.FindByIdAsync(roleid);

            if(role == null)
            {
                return View("error404");
            }

            for(int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if(model[i].IsChecked && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                } 
                else if (!model[i].IsChecked && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { id = roleid });
                }

            }

            return RedirectToAction("EditRole", new { id = roleid });
        }

    }
}
