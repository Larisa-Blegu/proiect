using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiect.Data;
using proiect.Models;

namespace proiect.Pages.Tipuri
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
            return Page();
        }

        [BindProperty]
        public TipBilet TipBilet { get; set; } = default!;
        

      
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TipBilet == null || TipBilet == null)
            {
                return Page();
            }

            _context.TipBilet.Add(TipBilet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
