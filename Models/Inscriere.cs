using System.ComponentModel.DataAnnotations;

namespace ProiectWeb.Models
{
    public class Inscriere
    {
        public int Id { get; set; }
        public int? MembruId { get; set; }
        public int? AbonamentId { get; set; }

        [DataType(DataType.Date)]

        public DateTime DataInscriere { get; set; }

        [DataType(DataType.Date)]

        public DateTime DataInchiere { get; set; }

        public Membru? Membru { get; set; }
        public Abonament? Abonament { get; set; }
    }
}
