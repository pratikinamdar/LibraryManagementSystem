using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public int Isbn { get; set; }
    }


    public class AuthorParams
    {
        public string AuthorName { get; set; }
        public int Isbn { get; set; }
    }
}
