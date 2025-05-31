using SQLite;

namespace BookTracker.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]  // Este es el de SQLite
        public string Title { get; set; }

        [MaxLength(100)]
        public string Author { get; set; }

        public string Status { get; set; } // Leído, En lectura, Por leer
        public int Rating { get; set; } // De 1 a 5
    }
}
