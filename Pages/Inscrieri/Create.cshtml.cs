using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiect.Data;
using proiect.Models;

namespace proiect.Pages.Inscrieri
{
    public class CreateModel : PageModel
    {
        private readonly proiect.Data.proiectContext _context;

        public CreateModel(proiect.Data.proiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CursID"] = new SelectList(_context.Curs, "ID", "Name"); 

            if (ViewData["ClientID"] == null)
            {
                var clientii = _context.Client.ToList();
                ViewData["ClientID"] = new SelectList(clientii, "ID", "ClientName");
            }
            if (ViewData["TipBiletID"] == null)
            {
                var tip = _context.TipBilet.ToList();
                ViewData["TipBiletID"] = new SelectList(tip, "ID", "BiletType");
            }
            return Page();
        }

        [BindProperty]
        public Inscriere Inscriere { get; set; } = default!;
        

        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Inscriere == null || Inscriere == null)
            {
                return Page();
            }

            _context.Inscriere.Add(Inscriere);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
