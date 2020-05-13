using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SRS.Common;

namespace SRS.Pages.Role
{
    public class AddOrEditModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private RoleManager<IdentityRole> _roleManager;
        [BindProperty]
        public IdentityRole Role { get; set; }

        public AddOrEditModel(RoleManager<IdentityRole> roleManager, ILogger<IndexModel> logger)
        {
            _roleManager = roleManager;
            _logger = logger;
        }
        public void OnGet(string id)
        {
            var role = _roleManager.Roles.FirstOrDefault(r => r.Id == id);
            if (role != null)
            {
                Role = role;
            }
            else
            {
                Role = new IdentityRole();
            }
        }

        public async Task<IActionResult> OnPost(IdentityRole role)
        {
            if (!ModelState.IsValid == false)
            {
                
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToPage("Index");
                }
                else
                    Utils.Errors(result, ModelState);
            }
            return Page();
        }
    }
}