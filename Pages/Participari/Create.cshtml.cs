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

namespace ProiectWeb.Pages.Participari
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
        ViewData["ClasaId"] = new SelectList(_context.Set<Clasa>(), "Id", "Nume");
            ViewData["MembruId"] = new SelectList(_context.Membru.Select(m => new
            {
                Id = m.Id,
                NumeComplet = m.Nume + " " + m.Prenume
            }), "Id", "NumeComplet");
            return Page();
        }

        [BindProperty]
        public Participare Participare { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Participare == null || Participare == null)
            {
                return Page();
            }

            _context.Participare.Add(Participare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
