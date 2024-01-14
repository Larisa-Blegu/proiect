using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect.Data;
using proiect.Models;

namespace proiect.Pages.Cursuri
{
    public class DetailsModel : PageModel
    {
        private readonly proiect.Data.proiectContext _context;

        public DetailsModel(proiect.Data.proiectContext context)
        {
            _context = context;
        }

      public Curs Curs { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Curs == null)
            {
                return NotFound();
            }

            var curs = await _context.Curs.FirstOrDefaultAsync(m => m.ID == id);
            if (curs == null)
            {
                return NotFound();
            }
            else 
            {
                Curs = curs;
            }
            return Page();
        }
    }
}
