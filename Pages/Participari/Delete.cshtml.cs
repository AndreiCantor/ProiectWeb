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

namespace ProiectWeb.Pages.Participari
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
      public Participare Participare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Participare == null)
            {
                return NotFound();
            }

            var participare = await _context.Participare.Include(i => i.Membru)
                    .Include(i => i.Clasa).FirstOrDefaultAsync(m => m.Id == id);

            if (participare == null)
            {
                return NotFound();
            }
            else 
            {
                Participare = participare;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Participare == null)
            {
                return NotFound();
            }
            var participare = await _context.Participare.FindAsync(id);

            if (participare != null)
            {
                Participare = participare;
                _context.Participare.Remove(Participare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
