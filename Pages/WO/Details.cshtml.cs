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
    public class DetailsModel : PageModel
    {
        private readonly SRS.Data.ApplicationDbContext _context;

        public DetailsModel(SRS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
