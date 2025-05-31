using SQLite;

namespace BookTracker.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]  
        public string Title { get; set; }

        [MaxLength(100)]
        public string Author { get; set; }

        public string Status { get; set; } 
        public int Rating { get; set; } 
    }
}
