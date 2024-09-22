using LibraryManagementSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController
    {

        private LibraryDatabase db;
        public AuthorController(IConfiguration config)
        {
            db = new LibraryDatabase(config.GetConnectionString("connstr"));
        }

        [HttpPost("Authors", Name = "PostAuthors")]

        public void PostAuthors(AuthorParams authorInput)
        {
            var newAuthor = new Author() { AuthorName= authorInput.AuthorName, Isbn = authorInput.Isbn};
            db.Author.Add(newAuthor);
            db.SaveChanges();
        }

        [HttpGet("Authors", Name = "GetAuthors")]
        public IEnumerable<Author> GetBooks()
        {
            return (from a in db.Author
                    select a);
        }
    }
}
