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

namespace proiect.Pages.Inscrieri
{
    public class EditModel : PageModel
    {
        private readonly proiect.Data.proiectContext _context;

        public EditModel(proiect.Data.proiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inscriere Inscriere { get; set; } 
        public SelectList CursSelectList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var inscriere =  await _context.Inscriere.FirstOrDefaultAsync(m => m.ID == id);
            if (inscriere == null)
            {
                return NotFound();
            }
            Inscriere = inscriere;
           ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ClientName");
           ViewData["CursID"] = new SelectList(_context.Curs, "ID", "Name");
           ViewData["TipBiletID"] = new SelectList(_context.TipBilet, "ID", "BiletType");
            return Page();
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Inscriere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscriereExists(Inscriere.ID))
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

        private bool InscriereExists(int id)
        {
          return (_context.Inscriere?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
