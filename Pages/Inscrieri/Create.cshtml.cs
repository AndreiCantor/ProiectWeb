using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectWeb.Data;
using ProiectWeb.Models;

namespace ProiectWeb.Pages.Inscrieri
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : PageModel
    {
        private readonly ProiectWeb.Data.ProiectWebContext _context;

        public CreateModel(ProiectWeb.Data.ProiectWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AbonamentId"] = new SelectList(_context.Abonament, "Id", "Tip");
            ViewData["MembruId"] = new SelectList(_context.Membru.Select(m => new
            {
                Id = m.Id,
                NumeComplet = m.Nume + " " + m.Prenume
            }), "Id", "NumeComplet");
            return Page();
        }

        [BindProperty]
        public Inscriere Inscriere { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Inscriere == null || Inscriere == null)
            {
                return Page();
            }

            _context.Inscriere.Add(Inscriere);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
