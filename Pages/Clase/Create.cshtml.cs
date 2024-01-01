using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectWeb.Data;
using ProiectWeb.Models;

namespace ProiectWeb.Pages.Clase
{
    public class CreateModel : PageModel
    {
        private readonly ProiectWeb.Data.ProiectWebContext _context;

        public CreateModel(ProiectWeb.Data.ProiectWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Clasa Clasa { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Clasa == null || Clasa == null)
            {
                return Page();
            }

            _context.Clasa.Add(Clasa);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
