using System.ComponentModel.DataAnnotations;

namespace ProiectWeb.Models
{
    public class Membru
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNasterii { get; set; }
        public string Email { get; set; }
        public string NumarTelefon { get; set; }

        public ICollection<Inscriere>? Inscrieri { get; set; }

    }
}
