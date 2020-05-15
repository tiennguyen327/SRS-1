using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SRS.Data;
using SRS.Models;

namespace SRS.Pages.WO
{
    public class DeleteModel : PageModel
    {
        private readonly SRS.Data.ApplicationDbContext _context;

        public DeleteModel(SRS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WorkOrder WorkOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkOrder = await _context.WorkOrder.FirstOrDefaultAsync(m => m.ID == id);

            if (WorkOrder == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkOrder = await _context.WorkOrder.FindAsync(id);

            if (WorkOrder != null)
            {
                _context.WorkOrder.Remove(WorkOrder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
