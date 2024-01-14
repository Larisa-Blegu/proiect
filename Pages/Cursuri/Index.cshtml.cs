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
    public class IndexModel : PageModel
    {
        private readonly proiect.Data.proiectContext _context;

        public IndexModel(proiect.Data.proiectContext context)
        {
            _context = context;
        }

        public IList<Curs> Curs { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Curs != null)
            {
                Curs = await _context.Curs
                    .Include(c=>c.Artist)
                    .ToListAsync();
            }
        }
    }
}
