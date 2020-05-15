using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRS.Data;
using SRS.Models;

namespace SRS.Pages.WO
{
    public class CreateModel : PageModel
    {
        private readonly SRS.Data.ApplicationDbContext _context;

        public CreateModel(SRS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WorkOrder WorkOrder { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.WorkOrder.Add(WorkOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
