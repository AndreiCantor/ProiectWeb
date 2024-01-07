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

namespace ProiectWeb.Pages.Abonamente
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
        public Abonament Abonament { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Abonament == null)
            {
                return NotFound();
            }

            var abonament =  await _context.Abonament.FirstOrDefaultAsync(m => m.Id == id);
            if (abonament == null)
            {
                return NotFound();
            }
            Abonament = abonament;
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

            _context.Attach(Abonament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbonamentExists(Abonament.Id))
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

        private bool AbonamentExists(int id)
        {
          return (_context.Abonament?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
