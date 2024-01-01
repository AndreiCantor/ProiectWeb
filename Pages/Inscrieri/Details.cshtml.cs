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
    public class DetailsModel : PageModel
    {
        private readonly ProiectWeb.Data.ProiectWebContext _context;

        public DetailsModel(ProiectWeb.Data.ProiectWebContext context)
        {
            _context = context;
        }

      public Inscriere Inscriere { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inscriere == null)
            {
                return NotFound();
            }

            var inscriere = await _context.Inscriere.FirstOrDefaultAsync(m => m.Id == id);
            if (inscriere == null)
            {
                return NotFound();
            }
            else 
            {
                Inscriere = inscriere;
            }
            return Page();
        }
    }
}
