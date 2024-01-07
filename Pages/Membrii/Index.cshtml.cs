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

namespace ProiectWeb.Pages.Membrii
{
    public class IndexModel : PageModel
    {
        private readonly ProiectWeb.Data.ProiectWebContext _context;

        private readonly UserManager<GymUser> _userManager;
        private readonly SignInManager<GymUser> _signInManager;

        public IndexModel(ProiectWeb.Data.ProiectWebContext context,
                          UserManager<GymUser> userManager,
                          SignInManager<GymUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IList<Membru> Membru { get;set; } = default!;

        public async Task OnGetAsync(string searchString)
        {

            IQueryable<Membru> membriQuery = _context.Membru.AsQueryable();

            var user = await _userManager.GetUserAsync(User);
            if (user != null && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                // Utilizatorul este admin, arată toți membrii
                if (!String.IsNullOrEmpty(searchString))
                {
                    membriQuery = membriQuery.Where(s => s.Nume.Contains(searchString)
                                                       || s.Prenume.Contains(searchString));
                }
            }
            else
            {
                // Utilizatorul este un membru obișnuit, arată doar propriul profil
                membriQuery = membriQuery.Where(m => m.Email == user.Email);
            }

            Membru = await membriQuery.ToListAsync();
        }
    }
}
