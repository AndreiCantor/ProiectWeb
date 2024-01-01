using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectWeb.Data;
using ProiectWeb.Models;

namespace ProiectWeb.Pages.Inscrieri
{
    public class IndexModel : PageModel
    {
        private readonly ProiectWeb.Data.ProiectWebContext _context;

        public IndexModel(ProiectWeb.Data.ProiectWebContext context)
        {
            _context = context;
        }

        public IList<Inscriere> Inscriere { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Inscriere != null)
            {
                Inscriere = await _context.Inscriere
                .Include(i => i.Abonament)
                .Include(i => i.Membru).ToListAsync();
            }
        }
    }
}
