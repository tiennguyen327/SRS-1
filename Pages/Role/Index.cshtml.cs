using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SRS.Pages.Role
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private RoleManager<IdentityRole> _roleManager;
        [BindProperty]
        public IEnumerable<IdentityRole> Roles { get; set; }

        public IndexModel(RoleManager<IdentityRole> roleManager, ILogger<IndexModel> logger)
        {
            _roleManager = roleManager;
            _logger = logger;
        }
        public void OnGet()
        {
            Roles = _roleManager.Roles.ToList();
        }
    }
}