using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        [Key]
        public int Isbn { get; set; }
        public string Title { get; set; }
        public DateTime PublicationYear { get; set; }
        public string Genre { get; set; }

        public string Publisher { get; set; }
        public string Language {  get; set; }
    }

    public class BookParams
    {
        public string Title { get; set; }
        public DateTime PublicationYear { get; set; }
        public string Genre { get; set; }

        public string Publisher { get; set; }
        public string Language { get; set; }
    }
}
