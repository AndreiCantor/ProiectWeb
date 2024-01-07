using System.ComponentModel.DataAnnotations;

namespace ProiectWeb.Models
{
    public class Membru
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage =
 "Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau AnaMaria")]
         public string? Nume { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string? Prenume { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNasterii { get; set; }
        public string Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau'0722.123.123' sau '0722 123 123'")]

        public string? NumarTelefon { get; set; }


        public ICollection<Inscriere>? Inscrieri { get; set; }

    }
}
