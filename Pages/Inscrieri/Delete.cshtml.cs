using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectWeb.Data;
using ProiectWeb.Models;

namespace ProiectWeb.Pages.Inscrieri
{
    [Authorize(Roles = "Admin")]

    public class DeleteModel : PageModel
    {
        private readonly ProiectWeb.Data.ProiectWebContext _context;

        public DeleteModel(ProiectWeb.Data.ProiectWebContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Inscriere Inscriere { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inscriere == null)
            {
                return NotFound();
            }

            var inscriere = await _context.Inscriere
                    .Include(i => i.Membru)
                    .Include(i => i.Abonament)
                    .FirstOrDefaultAsync(m => m.Id == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Inscriere == null)
            {
                return NotFound();
            }
            var inscriere = await _context.Inscriere.FindAsync(id);

            if (inscriere != null)
            {
                Inscriere = inscriere;
                _context.Inscriere.Remove(Inscriere);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
