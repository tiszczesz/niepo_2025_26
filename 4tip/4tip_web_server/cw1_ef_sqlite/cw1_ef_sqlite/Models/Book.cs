using System.ComponentModel;

namespace cw1_ef_sqlite.Models
{
    public class Book
    {
        public int Id { get; set; }

        [DisplayName("Tytuł")]
        public string Title { get; set; }

        [DisplayName("Autor")]
        public string Author { get; set; }

        [DisplayName("Rok wydania")]
        public int Year { get; set; }
    }
}
