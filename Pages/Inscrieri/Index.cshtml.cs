using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectWeb.Areas.Identity.Data;
using ProiectWeb.Data;
using ProiectWeb.Models;

namespace ProiectWeb.Pages.Inscrieri
{
    public class IndexModel : PageModel
    {
        private readonly ProiectWeb.Data.ProiectWebContext _context;

        private readonly UserManager<GymUser> _userManager;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IndexModel(ProiectWeb.Data.ProiectWebContext context, UserManager<GymUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Inscriere> Inscriere { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var inscriereQuery = _context.Inscriere
                .Include(i => i.Abonament)
                .Include(i => i.Membru)
                .AsQueryable();

            if (user != null && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                if (!string.IsNullOrEmpty(SearchString))
                {
                    inscriereQuery = inscriereQuery.Where(i => i.Membru.Nume.Contains(SearchString)
                                                             || i.Membru.Prenume.Contains(SearchString));
                }
            }
            else
            {
                inscriereQuery = inscriereQuery.Where(i => i.Membru.Email == user.Email);
            }

            Inscriere = await inscriereQuery.ToListAsync();
        }
    }
}
