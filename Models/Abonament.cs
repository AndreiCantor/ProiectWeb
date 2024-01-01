using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectWeb.Models
{
    public class Abonament
    {
        public int Id { get; set; }
        public string Tip { get; set; }

        [Column(TypeName = "decimal(6, 2)")]

        public decimal Pret { get; set; }

        public ICollection<Inscriere>? Inscrieri { get; set; }

    }
}
