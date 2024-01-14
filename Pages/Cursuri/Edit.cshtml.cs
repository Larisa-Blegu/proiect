using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiect.Data;
using proiect.Models;

namespace proiect.Pages.Cursuri
{
    public class EditModel : PageModel
    {
        private readonly proiect.Data.proiectContext _context;

        public EditModel(proiect.Data.proiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Curs Curs { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Curs == null)
            {
                return NotFound();
            }

            var curs =  await _context.Curs.FirstOrDefaultAsync(m => m.ID == id);
            if (curs == null)
            {
                return NotFound();
            }
            Curs = curs;

            ViewData["ArtistID"] = new SelectList(_context.Set<Artist>(), "ID", "Artist");

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ArtistID"] = new SelectList(_context.Set<Artist>(), "ID", "Artist");

                return Page();
            }

            _context.Attach(Curs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursExists(Curs.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CursExists(int id)
        {
          return (_context.Curs?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
