using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect.Data;
using proiect.Models;

namespace proiect.Pages.Tipuri
{
    public class DeleteModel : PageModel
    {
        private readonly proiect.Data.proiectContext _context;

        public DeleteModel(proiect.Data.proiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TipBilet TipBilet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TipBilet == null)
            {
                return NotFound();
            }

            var tipbilet = await _context.TipBilet.FirstOrDefaultAsync(m => m.ID == id);

            if (tipbilet == null)
            {
                return NotFound();
            }
            else 
            {
                TipBilet = tipbilet;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TipBilet == null)
            {
                return NotFound();
            }
            var tipbilet = await _context.TipBilet.FindAsync(id);

            if (tipbilet != null)
            {
                TipBilet = tipbilet;
                _context.TipBilet.Remove(TipBilet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
