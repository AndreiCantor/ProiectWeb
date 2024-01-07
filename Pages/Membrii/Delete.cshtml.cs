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

namespace ProiectWeb.Pages.Membrii
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
      public Membru Membru { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Membru == null)
            {
                return NotFound();
            }

            var membru = await _context.Membru.FirstOrDefaultAsync(m => m.Id == id);

            if (membru == null)
            {
                return NotFound();
            }
            else 
            {
                Membru = membru;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Membru == null)
            {
                return NotFound();
            }
            var membru = await _context.Membru.FindAsync(id);

            if (membru != null)
            {
                Membru = membru;
                _context.Membru.Remove(Membru);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
