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
    public class CreateModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public SelectList Roles { get; set; }
        [BindProperty]
        public ApplicationUser Account { get; set; }

        public CreateModel(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public void OnGet()
        {
            var roles = _roleManager.Roles.OrderBy(r => r.Name).ToList();
            Roles = new SelectList(roles, "Id", "Name");
            Account = new ApplicationUser();
        }

        public async Task<IActionResult> OnPost(ApplicationUser account)
        {
            var existUser = await _userManager.FindByEmailAsync(account.Email);

            if (existUser == null)
            {
                var role = await _roleManager.FindByIdAsync(account.SelectedRoleId);
                if (ModelState.IsValid)
                {
                    var user = new IdentityUser { UserName = account.Email, Email = account.Email };
                    IdentityResult result = await _userManager.CreateAsync(user, account.Password);
                    if (result.Succeeded)
                    {
                        var addRoleResult = await _userManager.AddToRoleAsync(user, role.Name);
                        if (addRoleResult.Succeeded)
                            return RedirectToPage("Index");
                        else
                            Utils.Errors(addRoleResult, ModelState);
                    }
                    else
                        Utils.Errors(result, ModelState);
                }
            }
            else
                ModelState.AddModelError("CreateUser", "The email already exists. Please use a different email!");
            return Page();
        }

        public async Task<IActionResult> Create(ApplicationUser account)
        {
            var existUser = await _userManager.FindByEmailAsync(account.Email);

            if (existUser == null)
            {
                var role = await _roleManager.FindByIdAsync(account.SelectedRoleId);
                if (ModelState.IsValid)
                {
                    var user = new IdentityUser { UserName = account.Email, Email = account.Email };
                    IdentityResult result = await _userManager.CreateAsync(user, account.Password);
                    if (result.Succeeded)
                    {
                        var addRoleResult = await _userManager.AddToRoleAsync(user, role.Name);
                        if (addRoleResult.Succeeded)
                            return RedirectToPage("Index");
                        else
                            Utils.Errors(addRoleResult, ModelState);
                    }
                    else
                        Utils.Errors(result, ModelState);
                }
            }
            else
                ModelState.AddModelError("CreateUser", "The email already exists. Please use a different email!");

            return Page();
        }
    }
}