using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiect.Data;
using proiect.Models;

namespace proiect.Pages.Cursuri
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
            ViewData["ArtistID"] = new SelectList(_context.Set<Artist>(), dataValueField: "ID", "ArtistName");
            return Page();
        }

        [BindProperty]
        public Curs Curs { get; set; } = default!;
        

   
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Curs == null || Curs == null)
            {
                return Page();
            }

            _context.Curs.Add(Curs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
