using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectWeb.Data;
using ProiectWeb.Models;

namespace ProiectWeb.Pages.Inscrieri
{
    [Authorize(Roles = "Admin")]

    public class EditModel : PageModel
    {
        private readonly ProiectWeb.Data.ProiectWebContext _context;

        public EditModel(ProiectWeb.Data.ProiectWebContext context)
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

            var inscriere =  await _context.Inscriere.FirstOrDefaultAsync(m => m.Id == id);
            if (inscriere == null)
            {
                return NotFound();
            }
            Inscriere = inscriere;
            ViewData["AbonamentId"] = new SelectList(_context.Abonament, "Id", "Tip");
            ViewData["MembruId"] = new SelectList(_context.Membru.Select(m => new
            {
                Id = m.Id,
                NumeComplet = m.Nume + " " + m.Prenume
            }), "Id", "NumeComplet");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Inscriere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscriereExists(Inscriere.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InscriereExists(int id)
        {
          return (_context.Inscriere?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
