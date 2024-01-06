using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectWeb.Data;
using ProiectWeb.Models;

namespace ProiectWeb.Pages.Membrii
{
    public class IndexModel : PageModel
    {
        private readonly ProiectWeb.Data.ProiectWebContext _context;

        public IndexModel(ProiectWeb.Data.ProiectWebContext context)
        {
            _context = context;
        }

        public IList<Membru> Membru { get;set; } = default!;

        public async Task OnGetAsync(string searchString)
        {

            var membriQuery = from m in _context.Membru
                              select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                membriQuery = membriQuery.Where(s => s.Nume.Contains(searchString)
                                               || s.Prenume.Contains(searchString));
            }

            Membru = await membriQuery.ToListAsync();
        }
    }
}
