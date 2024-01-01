using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectWeb.Data;
using ProiectWeb.Models;

namespace ProiectWeb.Pages.Clase
{
    public class DeleteModel : PageModel
    {
        private readonly ProiectWeb.Data.ProiectWebContext _context;

        public DeleteModel(ProiectWeb.Data.ProiectWebContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Clasa Clasa { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clasa == null)
            {
                return NotFound();
            }

            var clasa = await _context.Clasa.FirstOrDefaultAsync(m => m.Id == id);

            if (clasa == null)
            {
                return NotFound();
            }
            else 
            {
                Clasa = clasa;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Clasa == null)
            {
                return NotFound();
            }
            var clasa = await _context.Clasa.FindAsync(id);

            if (clasa != null)
            {
                Clasa = clasa;
                _context.Clasa.Remove(Clasa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
