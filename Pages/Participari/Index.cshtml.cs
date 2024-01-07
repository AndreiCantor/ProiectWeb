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

namespace ProiectWeb.Pages.Participari
{
    public class IndexModel : PageModel
    {
        private readonly ProiectWeb.Data.ProiectWebContext _context;

        private readonly UserManager<GymUser> _userManager;

        public IndexModel(ProiectWeb.Data.ProiectWebContext context, UserManager<GymUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IList<Participare> Participare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                Participare = await _context.Participare
                    .Include(p => p.Clasa)
                    .Include(p => p.Membru).ToListAsync();
            }
            else
            {
                Participare = await _context.Participare
                    .Include(p => p.Clasa)
                    .Include(p => p.Membru)
                    .Where(p => p.Membru.Email == user.Email).ToListAsync();
            }
        }
    }
}
