using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectWeb.Models;

namespace ProiectWeb.Data
{
    public class ProiectWebContext : DbContext
    {
        public ProiectWebContext (DbContextOptions<ProiectWebContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectWeb.Models.Membru> Membru { get; set; } = default!;

        public DbSet<ProiectWeb.Models.Abonament>? Abonament { get; set; }
    }
}
