using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SRS.Common;

namespace SRS.Pages.Role
{
    public class DeleteModel : PageModel
    {
        private RoleManager<IdentityRole> _roleManager;
        [BindProperty]
        public IdentityRole Role { get; set; }
        public DeleteModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
                Role = role;
            else
                ModelState.AddModelError("",string.Format("Role {0} not found!", id));

            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(Role.Id);
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToPage("Index");
                else
                    Utils.Errors(result, ModelState);
            }
            return Page();
        }
    }
}