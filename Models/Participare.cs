using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ProiectWeb.Models
{
    public class Participare
    {
        public int Id { get; set; }
        public int? MembruId { get; set; }
        public int? ClasaId { get; set; }

        public DateTime DataOra { get; set; }

        // Relații
        public Membru? Membru { get; set; }
        public Clasa? Clasa { get; set; }
    }
}
