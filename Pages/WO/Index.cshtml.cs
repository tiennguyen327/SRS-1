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
    public class IndexModel : PageModel
    {
        private readonly SRS.Data.ApplicationDbContext _context;

        public IndexModel(SRS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<WorkOrder> WorkOrder { get;set; }

        public async Task OnGetAsync()
        {
            WorkOrder = await _context.WorkOrder.ToListAsync();
        }
    }
}
