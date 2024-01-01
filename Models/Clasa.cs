namespace ProiectWeb.Models
{
    public class Clasa
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Descriere { get; set; }
        public string Instructor { get; set; }

        // Relații
        public ICollection<Participare>? Participari { get; set; }
    }
}
