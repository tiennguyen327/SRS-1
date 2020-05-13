using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRS.Common;
using SRS.Models;

namespace SRS.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        [BindProperty]
        public IEnumerable<ApplicationUser> Accounts { get; set; }

        public IndexModel(ILogger<IndexModel> logger, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var accounts = new List<ApplicationUser>();

            foreach (var u in users)
            {
                var role = await GetRolesOfUser(u);
                var account = new ApplicationUser
                {
                    Id = u.Id,
                    Email = u.Email,
                    Role = role
                };

                accounts.Add(account);
            }

            Accounts = accounts;

            return Page();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToPage("Index");
                else
                    Utils.Errors(result, ModelState);
            }
            else
                ModelState.AddModelError("Delete", "User not found!");
            return Page();
        }

        private async Task<string> GetRolesOfUser(IdentityUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var role = string.Empty;
            foreach (var r in roles)
            {
                if (!role.Contains(","))
                {
                    role = r;
                }
                else
                {
                    role = "," + r;
                }
            }

            return role;
        }

    }
}