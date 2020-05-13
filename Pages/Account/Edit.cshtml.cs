using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRS.Common;
using SRS.Models;

namespace SRS.Pages.Account
{
    public class EditModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        [BindProperty]
        public SelectList Roles { get; set; }
        [BindProperty]
        public ApplicationUser Account { get; set; }

        public EditModel(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async void OnGet(string id)
        {
            var roleList = _roleManager.Roles.OrderBy(r => r.Name).ToList();
            var editUser = await _userManager.FindByIdAsync(id);
            if (editUser != null)
            {
                var roles = await _userManager.GetRolesAsync(editUser);
                string roleId = string.Empty;
                if (roles.Count > 0)
                {
                    roleId = roleList.Find(r => r.Name == roles[0]).Id;
                }
                Account = new ApplicationUser
                {
                    Id = editUser.Id,
                    Email = editUser.Email,
                    SelectedRoleId = roleId
                };
                
                Roles = new SelectList(roles, "Id", "Name");
            }
            else
                ModelState.AddModelError("EditUser", "User not found!");
        }

        public async Task<IActionResult> Edit(ApplicationUser account)
        {
            var user = await _userManager.FindByIdAsync(account.Id);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(account.Email))
                    user.Email = account.Email;
                else
                    ModelState.AddModelError("", "Email cannot be empty!");

                if (string.IsNullOrEmpty(account.SelectedRoleId))
                    ModelState.AddModelError("", "Role cannot be empty!");

                if (!string.IsNullOrEmpty(account.Email) && !string.IsNullOrEmpty(account.SelectedRoleId))
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var removeRole = await _userManager.RemoveFromRoleAsync(user, roles[0]);
                        if (removeRole.Succeeded)
                        {
                            var role = await _roleManager.FindByIdAsync(account.SelectedRoleId);
                            var updateRole = await _userManager.AddToRoleAsync(user, role.Name);
                            if (updateRole.Succeeded)
                            {
                                return RedirectToPage("Index");
                            }
                            else
                                Utils.Errors(updateRole, ModelState);
                        }
                        else
                            Utils.Errors(removeRole, ModelState);
                    }
                    else
                        Utils.Errors(result, ModelState);
                }
                else
                    ModelState.AddModelError("", "User not found!");
            }
            return Page();
        }
    }
}